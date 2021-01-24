    private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                string username = Username.Text;
                string password = Password.Text;
                using (StreamWriter sw = new StreamWriter("C:\\Users\\omere\\Desktop\\Username.txt"))
                {
                    sw.WriteLine(username);
                    sw.WriteLine(password);
                }
               var lines = File.ReadAllLines("C:\\Users\\omere\\Desktop\\Username.txt");
                if (username != lines[0] || password != lines[1]  )
                {
                    ErrorDisp.Text = "Login failed. Check if you have typed in the correct username and password";
                }
    
            }
