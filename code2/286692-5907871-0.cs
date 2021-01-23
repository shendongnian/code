    public Form1 : Form
    {
        public static void CreateNew()
        {
            using (var form = new Form1())
            {
                form.ShowDialog();
            }
        }
        [...]
    }
