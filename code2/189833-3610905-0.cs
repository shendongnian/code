        protected void Page_Load(object sender, EventArgs e)
        {
            string s = myFunction(PopulateTestList());
            this.TextBox1.Text = s;
        }
        protected List<int> PopulateTestList()
        {
            List<int> thisList = new List<int>();
            thisList.Add(22);
            thisList.Add(33);
            thisList.Add(44);
            return thisList;
        }
        protected string myFunction(List<int> a)
        {
            return string.Join(",", a);
        }
    }
