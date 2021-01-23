             for (int i = 0; i < dataGridView1.Rows.Count; i++)
            	{
            		for (int j = 0; j < dataGridView1.Columns.Count; j++)
            		{
            			DataGridViewCell cell = dataGridView1[j, i];
            			object value = cell.Value;
            			if (value == string.Empty)
            			{
                                 //do
            			}
            		}
            	}
