            Application.ThreadException +=
                (o, args) =>
                    {
                        // Case 1
                        MessageBox.Show(args.Exception.ToString());
                    };
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                // Case 2
                MessageBox.Show(ex.ToString());
            }
