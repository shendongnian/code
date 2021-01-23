    private void FillCombobox()
            {
                using (mydatabaseEntities mydatabaseEntities = new mydatabaseEntities())
                {
                    List<usepurpose> usepurposes = mydatabaseEntities.usepurposes.ToList();              
                    DataTable dt = new DataTable();
                    dt.Columns.Add("id");
                    dt.Columns.Add("Name");
                    dt.Rows.Add(-1, "test row");
                    foreach (usepurpose usepurpose in usepurposes)
                    {
                        dt.Rows.Add(usepurpose.id, usepurpose.Name);
                    }
                    usepurposeComboBox.ValueMember = dt.Columns[0].ColumnName;
                    usepurposeComboBox.DisplayMember = dt.Columns[1].ColumnName;
                    usepurposeComboBox.DataSource = dt;
                }
            }
