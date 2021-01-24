csharp
using (var connection = new MySqlConnection(ConString))
{
    connection.Open();
    using (var command = new MySqlCommand(@"UPDATE harga_semasa SET we_buy=@we_buy, we_sell=@we_sell, idharga_semasa=@idharga_semasa WHERE type=@type;", connection)
    {
        command.Parameters.AddWithValue("@we_buy", this.textBox1.Text);
        command.Parameters.AddWithValue("@we_sell", this.textBox2.Text);
        command.Parameters.AddWithValue("@idharga_semasa ", this.label5.Text);
        command.Parameters.AddWithValue("@type", this.label1.Text);
        // use this to run the query (without MySqlDataReader)
        command.ExecuteNonQuery();
    }
    // execute your second query the same way here
    MessageBox.Show("Data Updated");
}
