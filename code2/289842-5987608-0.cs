        public static void Main()
        {
            using (var signInForm = new SignInForm())
            {
                if (signInForm.ShowDialog() != DialogResult.OK)
                    return;
            }
            Application.Run(new MainForm());
        }
