    Ok I madesome change now it works fine at first change Resource Class to 
    
        public class Resource
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int InitialLevel { get; set; }
    //added by dx
            public new string ToString()
            {
                return Name;
            }
        }
    
    Create New Class for grid vombo 
    
        public class  ComboSource
        {
            public string Name
            {
                get
                {
                    if (SourceValue != null)
                        return SourceValue.ToString();
                    return string.Empty;
                }
            }
            public Resource SourceValue{ get; set; }
    
        }
    
           private List<ComboSource> resources = new List<ComboSource>();
                this.resources.Add(new ComboSource() { SourceValue = new Resource() { Name = "rs1", Description = "a"} });
                this.resources.Add(new ComboSource() { SourceValue = new Resource() { Name = "rs2", Description = "b" } });
                this.resources.Add(new ComboSource() { SourceValue = new Resource() { Name = "rs3", Description = "c" } });
    
    and 
    
            this.dataGridView1.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "Resource",
                DataPropertyName = "Resource",
                ValueMember = "SourceValue",
                DataSource = new BindingSource { DataSource = this.resources },
                ValueType = typeof(Resource),
                DisplayMember = "Name"
            });
