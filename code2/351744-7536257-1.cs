        BindingList<USState> USStates;
        public Form1()
        {
            InitializeComponent();
            USStates = new BindingList<USState>();
            USStates.Add(new USState("Alabama", "AL"));
            USStates.Add(new USState("Washington", "WA"));
            USStates.Add(new USState("West Virginia", "WV"));
            USStates.Add(new USState("Wisconsin", "WI"));
            USStates.Add(new USState("Wyoming", "WY"));
            listBox1.DataSource = USStates;
            listBox1.DisplayMember = "LongName";
            listBox1.ValueMember = "ShortName";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var removeStates = (from state in USStates
                                where state.ShortName == "AL"
                                select state).ToList();
            removeStates.ForEach( state => USStates.Remove(state) );
        }
