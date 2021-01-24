    <div>
                <asp:FileUpload ID="upldGradeReport" runat="server" />
                <asp:FileUpload ID="upldExpenseReceipt" runat="server" />
    
                <asp:Button ID="btnSubmitForm" OnClick="SubmitButton_Click" runat="server" Text="Submit" />
            </div>
 
    protected void SubmitButton_Click(object sender, EventArgs e)
            {
                sendToSharePoint();
                Response.BufferOutput = true;
                Response.Redirect("Submission.aspx");
            }
    
            protected void sendToSharePoint()
            {
    
                try
                {
                    string siteUrl = "https://tenant.sharepoint.com/sites/lee";
    
                    ClientContext clientContext = new ClientContext(siteUrl);
                    SecureString securePassword = new SecureString();
                    foreach (char c in "password".ToCharArray()) securePassword.AppendChar(c);
                    clientContext.Credentials = new SharePointOnlineCredentials("lee@tenant.onmicrosoft.com", securePassword);                
                    string sDocName = string.Empty;
                    string sDocName1 = string.Empty;
                    Uri uri = new Uri(siteUrl);
                    string sSPSiteRelativeURL = uri.AbsolutePath;
                    sDocName = UploadFile(clientContext,upldGradeReport.FileContent, upldGradeReport.FileName, sSPSiteRelativeURL, "MyDoc");
                    sDocName1 = UploadFile(clientContext,upldExpenseReceipt.FileContent, upldExpenseReceipt.FileName, sSPSiteRelativeURL, "MyDoc");
    
                    //prior CSOM code to insert values into a new List Item exists here
    
                    //clientContext.ExecuteQuery();
                }
                catch (Exception ex)
                {
                    String ThisError = ex.Message;
                }
            }
    
            public String UploadFile(ClientContext clientContext,Stream fs, string sFileName, string sSPSiteRelativeURL, string sLibraryName)
            {
                string sDocName = string.Empty;
                try
                {
                    var sFileURL = String.Format("{0}/{1}/{2}", sSPSiteRelativeURL, sLibraryName, sFileName);
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, sFileURL, fs, true);
                    sDocName = sFileName;
                }
                catch (Exception ex)
                {
                    sDocName = string.Empty;
                    //SPErrorMsg = ex.Message;
                }
                return sDocName;
            }
