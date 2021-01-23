        public Form1()
        {
            string string1 = "test" ?? test();
            MessageBox.Show(string1);
        }
        private string test()
        {
            MessageBox.Show("does not short circuit");
            return "test";
        }
