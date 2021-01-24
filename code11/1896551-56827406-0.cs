public void Delete(Ship ship)
{
    using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
    {
        connection.Open();
        SqlCommand commandDelete = new SqlCommand("DELETE FROM Ship WHERE id = " + ship.Id, connection);
        commandDelete.ExecuteNonQuery();
     }
}
private void Button3_Click(object sender, EventArgs e)
{   
    using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
    {
        if (dataGridViewShips.SelectedRows.Count == 1)
        {
            Ship ship = (Ship)dataGridViewShips.SelectedRows[0].DataBoundItem;
            db.Delete(ship);
            dataGridViewShips.DataSource = db.GetAll();
        }
    }
}
