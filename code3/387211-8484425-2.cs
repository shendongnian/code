    static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());
                Form1 frm = new Form1();
                GlobalVariables.FormsList = new List<Form1>();  //new
                GlobalVariables.FormsList.Add(frm);             //new
                frm.Show();
                Application.Run();
            }
