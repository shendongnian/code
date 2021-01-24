        protected void Page_Load(object sender, EventArgs e)
        {
          // Gets the name if authenticated.
                if (User.Identity.IsAuthenticated)
                    Label1.Text = User.Identity.Name;
                else
                    Label1.Text = "No user identity available.";
            // Clean the Result TextBox
          
            // Initialize PowerShell engine
            var shell = PowerShell.Create();
            // Add the script to the PowerShell object
            // shell.Commands.AddScript(Input.Text);
            // shell.Commands.AddScript("D:\\Local_Scripts\\sessioncall.ps1");
            shell.Commands.AddCommand("c:\\Local_Scripts\\sessioncall.ps1");
            // Add Params
            // shell.Commands.AddParameter(null,User.Identity.Name);
            // shell.Commands.AddParameter("Username", Label1.Text);
            shell.Commands.AddArgument(User.Identity.Name);
            // Execute the script
            var results = shell.Invoke();
            // display results, with BaseObject converted to string
            // Note : use |out-string for console-like output
            if (results.Count > 0)
            {
                // We use a string builder ton create our result text
                var results2 = shell.Invoke();
                foreach (var psObject in results)
                {
                    // Convert the Base Object to a string and append it to the string builder.
                    // Add \r\n for line breaks
                    var UserFullName = (psObject.Members["UserFullName"]);
                    var BrokeringTime = (psObject.Members["BrokeringTime"]);
                    var ClientName = (psObject.Members["ClientName"]);
                    var DesktopGroupName = (psObject.Members["DesktopGroupName"]);
                    var SessionState = (psObject.Members["SessionState"]);
                    var Uid = (psObject.Members["Uid"]);
                    var MachineName = (psObject.Members["MachineName"]);
                    var ENV = (psObject.Members["ENV"]);
                    // builder.Append(psObject.BaseObject.ToString() + "\r\n");
                }
                this.ResultGrid.DataSource = results2;
                this.ResultGrid.DataBind();
            }
            }
