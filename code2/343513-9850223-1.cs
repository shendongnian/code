        {
            bool passwordChanged = false;
            DirectoryEntry oDE = GetUser(UserName, strOldPassword);
            if (oDE != null)
            {
                try
                {
                    // Change the password.
                    oDE.Invoke("ChangePassword", new object[] { strOldPassword, strNewPassword });
                    passwordChanged = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error changing password. Reason: " + ex.Message);
                }
            }
            return passwordChanged;
        }
