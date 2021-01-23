                if (cmd2.Equals("1"))
                {
                    this.Hide();
                    CarerHomePage CarerHomePage = new CarerHomePage();
                    CarerHomePage.Show();
                }
                else if (cmd2.Equals("2"))
                {
                    this.Hide();
                    AdministratorHome AdministratorHome = new AdministratorHome();
                    AdministratorHome.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Login Credentials");
                }
