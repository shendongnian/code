        try
            {
                USUARIO usuario = bl.EncontrarUsuarioPorUsername(Usuario);
                string savedPasswordHash = usuario.PASSWORD;
                /* Extract the bytes */
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                /* Get the salt */
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                /* Compute the hash on the password the user entered */
                var pbkdf2 = new Rfc2898DeriveBytes(Password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                /* Compare the results */
                bool isvalidated = true;
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        isvalidated = false;
                        break;
                        
                    }
                }
                if (isvalidated == false)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    //MessageBox.Show("Login exitoso!");
                    //shou your ListUsersView.xaml call it from your Views Library Class and set datacontext.
                    
                     WpfCustomControlLibrary1.ListUsersView listviewsc = new WpfCustomControlLibrary1.ListUsersView();
                     listviewsc.Show();
                     
                      //you can use the Application.Current.MainWindow method to find the MainWindow. Then, hide
                      BtnWindowsForm window = (BtnWindowsForm)Application.Current.MainWindow;
                      window.Close();//hide
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Contrasena Incorrecta");
            }
