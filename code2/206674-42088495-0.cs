				 try
					{
						for (int i = 0; i < 1000; i++)
						{
							dataGridView1.Columns.Add(i.ToString(), i.ToString());
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
