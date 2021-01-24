using (SqlCommand com = new SqlCommand("UPDATE tabl2 SET TEL8=@TEL8 WHERE id=@id and CIVILIDD=@CIVILIDD ", con))
{
    com.Parameters.Add("@id", SqlDbType.Int);
    com.Parameters.Add("@CIVILIDD", SqlDbType.BigInt);
    com.Parameters.Add("@TEL8", SqlDbType.NVarChar);
    foreach (DataGridViewRow row in datagridView1.Rows)
    {
        com.Parameters["@id"].Value = dataGridView1.Rows[i].Cells[0].Value);
        com.Parameters["@CIVILIDD"].Value = dataGridView1.Rows[i].Cells[1].Value);
        com.Parameters["@TEL8"].Value =  dataGridView1.Rows[i].Cells[2].Value.ToString());
    }
    com.ExecuteNonQuery();
}
or
alter your db to `single_user` before running the `update` then reverting it back to `multi_user`
"Alter Database {databaseName} SET SINGLE_USER With ROLLBACK IMMEDIATE"
//your update commands
"Alter Database {databaseName} SET MULTI_USER With ROLLBACK IMMEDIATE"
