        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (e.Args.Length > 0)
            {
                MessageBox.Show($"You have passed:{e.Args.Length} arguments," +
                    $" value are {string.Join( ",",e.Args)}");
            }
        }
    }`
