        internal static string GetSenderEmailAddress(ref Outlook.MailItem oM)
        {
            Outlook.PropertyAccessor oPA = null;
            Outlook.AddressEntry oSender = null;
            Outlook.ExchangeUser oExUser = null;
            string SenderID;
            string senderEmailAddress;
            try
            {                
                if (oM.SenderEmailAddress.Contains("@") && oM.SenderEmailAddress.Contains(".com")) //Handing smtp email addresses
                {
                    senderEmailAddress = oM.SenderEmailAddress;
                }
                else //Handing exchange email addresses
                {
                    // Create an instance of PropertyAccessor 
                    oPA = oM.PropertyAccessor;
                    // Obtain PidTagSenderEntryId and convert to string 
                    SenderID = oPA.BinaryToString(oPA.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x0C190102"));
                    // Obtain AddressEntry Object of the sender 
                    oSender = Globals.ObjNS.GetAddressEntryFromID(SenderID);
                    oExUser = oSender.GetExchangeUser();
                    senderEmailAddress = oExUser.PrimarySmtpAddress;
                }
                Debug.DebugMessage(3, "OutlookHelper : GetSenderEmailAddress() : Completed");
                return senderEmailAddress;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
                return null;
            }
            finally
            {
                if (oExUser != null) Marshal.ReleaseComObject(oExUser);
                if (oSender != null) Marshal.ReleaseComObject(oSender);
                if (oPA != null) Marshal.ReleaseComObject(oPA);
            }
        }
