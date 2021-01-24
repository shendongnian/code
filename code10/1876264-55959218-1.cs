        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormCreationFilter mf = new FormCreationFilter();
            Application.AddMessageFilter(mf);
            Application.Run(new Form1());
            Application.RemoveMessageFilter(mf);
            foreach (KeyValuePair<string, Int32> kvp in mf.formCounter)
            {
                Debug.Print($"{kvp.Key} opened {kvp.Value} times. ");
            }
        }
