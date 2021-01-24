            dataGridView1.DataSource = new List<Element> {
                new Element{ EditableDate = DateTime.Now.AddDays(-1)},
                new Element{ EditableDate = DateTime.Now},
                new Element{ EditableDate = DateTime.Now.AddDays(1)}
            }; ;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnF2;
