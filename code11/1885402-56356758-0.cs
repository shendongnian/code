    static void Main(string[] args)
        {
            TestForm form = new TestForm();
            form.Load += Form_Load;
            Application.Run(form);
            
        }
        private static async void Form_Load(object sender, EventArgs e)
        {
            var form = sender as Form;
            string s = await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                return "Plop";
            });
            if (s == "Plop")
            {
                form?.Close();
            }
        }
