    if (fLogin.ShowDialog() == DialogResult.OK)
            {
                main = new Main();
                main.Username = fLogin.UsernameText;
                Application.Run(main);
            }
