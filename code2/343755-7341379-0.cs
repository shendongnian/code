            ...
            bindingSource1.DataSource = m_Scenario.Fiction;
            comboBox1.DisplayMember = "Key";
            comboBox1.DataSource = bindingSource1;
            textBox1.DataBindings.Add("Text", bindingSource1, "Value");
         }
    }
    internal class Scenario
    {
        private readonly Dictionary<int, string> _fiction = 
             new Dictionary<int, string> { { 1, "111" }, {2,"112"}, {3,"113"} };
        public Dictionary<int, string> Fiction
        {
            get { return _fiction; }
        }
    }
