                var result = command.ExecuteScalar();
                my.Close();
    
    
                if (result !=null )
                {
                    AdminPanel bb = new AdminPanel();
                    bb.Show();
                }
                else
                {
                    MessageBox.Show("INCORRECT USER/PASS!");
    
                }
