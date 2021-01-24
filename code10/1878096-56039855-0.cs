SqlCommand command = new SqlCommand("SELECT rangemaster.code as ... where rangemaster.code = @param");
command.Parameters.Add("@param",SQlDbType.Nvarchar).Value = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", conn);
You can use this but i would suggest you to use parameters. They can save you from a SQL Injection.
Use Something Like this:
SqlCommand command = new SqlCommand("SELECT rangemaster.code as ... where rangemaster.code = @param");
command.Parameters.Add("@param",SQlDbType.Nvarchar).Value = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
Always practice this for more secure code.
