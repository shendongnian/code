            wb.Visible = true;
            wb.Navigate(MainSite);
            {
                while (wb.Busy) { Thread.Sleep(100); }
                document = ((HTMLDocument)wb.Document);
                if (document.body.outerHTML.Contains("Logout")) { Loggedin = true; }
                if (!(document.body.outerHTML.Contains("Logout"))) { Loggedin = false; }
                if (Loggedin == false)
                {
                    element = document.getElementById("Username");
                    username = (HTMLInputElement)element;
                    username.value = Username;
                    username = null;
                    element = document.getElementById("Passwd");
                    password = (HTMLInputElement)element;
                    password.value = Password;
                    password = null;
                    element = document.getElementById("Submit");
                    Submit = (HTMLInputElement)element;
                    Submit.click();
                    Submit = null;
                    while (wb.Busy) { Thread.Sleep(100); }
                    SourceCode = document.body.outerHTML;
                }
            }
