           static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            imgsplash f = new imgsplash();
            f.Show();
            System.Threading.Thread.Sleep(2000);
            f.Close();
            Application.Run(new Form1());
        }
