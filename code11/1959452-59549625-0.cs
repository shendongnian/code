     private void Form2_Load(object sender, EventArgs e)
        {
            SendVal();
        }
        public string _pval { get; set; }
        private void SendVal()
        {
            Form1 f = new Form1();
            _pval = "set the value here";
            f._rval = _pval;
            f.Show();
        }
