            if (Application.Current.Properties["ArbitraryArgName"] != null)
            {
                string fname = Application.Current.Properties["ArbitraryArgName"].ToString();
                MainWindow mw = new MainWindow();
                mw.Show();
                mw.readVcard(fname);
            }
