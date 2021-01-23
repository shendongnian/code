        List<FactColumn> FactColumns = new List<FactColumn>();
        List<string> SelectedColumns = new List<string>();
        private void Form2_Load(object sender, EventArgs e)
        {
            FactColumns.Add(new FactColumn() { DataType = "int", Name = "int" });
            FactColumns.Add(new FactColumn() { DataType = "string", Name = "string" });
            SelectedColumns.Add("string");
            var lst = from fc in this.FactColumns join column in SelectedColumns on fc.Name equals column select new { fc.DataType,  fc.Name};
            foreach (var column in lst)
            {
                MessageBox.Show(column.Name);
            }
        }
    
        public class FactColumn
        {
            public string DataType { get; set; }
            public string Name { get; set; }
        }
 
