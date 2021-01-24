private void Button2_Click(object sender, EventArgs e)
{
    cmd.CommandType = CommandType.Text;
    cmd.Connection = conn;
    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
    {
        cmd.CommandText += // Append additional statements
        "INSERT INTO tabl (Name_Arabic, 
        // ...
        ) values" +
        "(N'" + dataGridView1.Rows[i].Cells[0].Value + 
             //..."');" // End each statement with ;
        ;
    } 
    conn.Open();
    cmd.ExecuteNonQuery();
    conn.Close();
    MessageBox.Show("saved");
}
