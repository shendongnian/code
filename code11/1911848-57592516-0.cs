    if(ModelState.IsValid)
    {
        try
        {
            Dictionary <string,string[]> log = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string[]>>(gridData);
                    
            foreach (KeyValuePair<string,string[]> keyValue in log)
            {
                if (keyValue.Value[9] == "1")//Update this row based on the checkbox being checked
                {
                    var AttendeeID = keyValue.Value[0];
                    int intAttendeeID = 0;
                    if (int.TryParse(AttendeeID, out intAttendeeID))//Make sure the AttendeeID is valid
                    {
                        var LName = keyValue.Value[1];
                        var FName = keyValue.Value[2];
                        var Title = keyValue.Value[3];
                        var kOrgID = keyValue.Value[4];
                        var Org = keyValue.Value[5];
                        var City = keyValue.Value[7];
                        var State = keyValue.Value[8];
                        var LegalApproval = keyValue.Value[9];
                           
                        tblAttendee att = db.tblAttendees.Find(Convert.ToInt32(AttendeeID));
                        att.FName = FName;
                        att.LName = LName;
                        att.Title = Title;
                        att.kOrgID = Convert.ToInt32(kOrgID);
                        att.Organization = Org;
                        att.City = City;
                        att.State = State;
                        att.LegalApprovedAtt = Convert.ToBoolean(LegalApproval);
                    }
                }
            }
            db.SaveChanges();
                 
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
