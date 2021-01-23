            this.dataGridView1.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "Resource",
                DataPropertyName = "Resource",
                ValueMember = "SourceValue",
                DataSource = new BindingSource { DataSource = this.resources },
                ValueType = typeof(Resource),
                DisplayMember = "Name"
            });
