     private void Form1_Load(object sender, EventArgs e)
        {
            List<TestClass> list = new List<TestClass>();
            list.Add(new TestClass() { Prop1="QC1",Prop2="1.000"});
            list.Add(new TestClass() { Prop1 = "QC2", Prop2 = "2.000" });
            list.Add(new TestClass() { Prop1 = "QC3", Prop2 = "3.000" });
            list.Add(new TestClass() { Prop1 = "QC4", Prop2 = "4.000" });
            dataGridView1.DataSource = list;
            
        }
        public class TestClass
        {
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
            public TestClass()
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == "QC3" && row.Cells[1].Value == "3.000")
                    row.Selected = true;
            }
        }
