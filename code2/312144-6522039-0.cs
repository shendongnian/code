    private void PopulateGridView(DataTable dt)
    {
            
        if (dt != null)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = dt;
                }
            }
    }
    }
