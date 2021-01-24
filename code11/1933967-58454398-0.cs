        private async Task TryLoginAsync()
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Password.Trim();
            string errorTitle;
            string errorDetail;
            /*Your Type*/ object programAdmin;
            bool result;
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                result = await Task.Run(new Func<bool>(() =>
                {
                    try
                    {
                        programAdmin = _dbAdmins.FindBy(x => x.Username.ToLower() == username.ToLower());
                        if (programAdmin != null)
                        {
                            if (string.Equals(EncryptionManager.Decrypt(BotDBConfiguration.EncryptionKey, programAdmin.Password), password))
                            {
                                programAdmin.DateLastLogin = DateTime.Now;
                                programAdmin.TotalLogins += 1;
                                _dbAdmins.Update(programAdmin);
                                return true;
                            }
                            else
                            {
                                errorTitle = "Password error";
                                errorDetail = "The given password is incorrect, please try again...";
                            }
                        }
                        else
                        {
                            errorTitle = "Admin not found";
                            errorDetail = "The given username cannot be found in the admin database, please try again...";
                        }
                    }
                    catch (Exception)
                    {
                        errorTitle = "Connection error";
                        errorDetail = "Cannot connect to the database, please try again later...";
                    }
                    return false;
                }));
            }
            else
            {
                errorTitle = "Missing information";
                errorDetail = "Please fill in all the required information...";
            }
            if (result)
            {
                var firstTimeLoginPanel = new UpdatePasswordWindow(programAdmin);
                firstTimeLoginPanel.Show();
                Close();
            }
            else
            {
                cpLoader.Visibility = Visibility.Collapsed;
                AlertManager.ShowAlertMessage(errorTitle, errorDetail);
            }
        }
Notice I changed the the internal `Task` to a run a `Func<bool>` instead of an `Action`. This way it can return a value `bool` to indicate the result. Because you are using a lambda function, you can also access variables like `errorTitle` from both threads, which I am using to pass the details of any error back to the main thread. Instead of sharing variables between threads, you could also change the return type of `Task` to be a more complex class or a `Tuple`.
These changes don't really alter the functionality of the code, but in my opinion they make it more readable/maintainable by separating out the main-thread code from the background-thread code.
