    string ssid = "abc wifi network";
                AccessPoint selectedAP = null;
                bool isApFound = false;
                foreach (AccessPoint ap in accessPoints)
                {
                    if (ap.Name.Equals(ssid, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedAP = ap;
                        isApFound = true;
                        break;
                    }                    
                }
                if(!isApFound)
                {
                    MessageBox.Show("SSID: " + ssid + " not found in range.");
                    return;
                }
                // Auth
                AuthRequest authRequest = new AuthRequest(selectedAP);
                bool overwrite = true;
                if (authRequest.IsPasswordRequired)
                {
                    if (selectedAP.HasProfile)
                    // If there already is a stored profile for the network, we can either use it or overwrite it with a new password.
                    {
                        var confirmResult = MessageBox.Show("A network profile already exist, do you want to use it ?", "Confirm Yes ?", MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            overwrite = false;
                        }
                    }
                    if (overwrite)
                    {
                        if (authRequest.IsUsernameRequired)
                        {
                            authRequest.Username = Microsoft.VisualBasic.Interaction.InputBox("Please enter Wifi username", "Wifi Username", "", -1, -1);
                        }
                        authRequest.Password = PasswordPrompt(selectedAP);
                        if (authRequest.IsDomainSupported)
                        {
                            authRequest.Domain = Microsoft.VisualBasic.Interaction.InputBox("Please enter Wifi domain", "Wifi Domain", "", -1, -1);
                        }
                    }
                }
                selectedAP.ConnectAsync(authRequest, overwrite, OnConnectedComplete);
