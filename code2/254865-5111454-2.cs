        static void Main()
        {
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops! Can I has " + ex.Message + "?");
            }
        }
