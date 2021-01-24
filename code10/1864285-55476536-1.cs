    private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter();
            con.Open();if (s < 250)  label_mesaj.Text = "1800";
            da.UpdateCommand = new SqlCommand("Update Clienti set kcal_zilnice= '" + label_mesaj.Text + "' where email= '" + Form3.client.email.ToString() + "'", con);
            da.UpdateCommand.ExecuteNonQuery();
            da.UpdateCommand.Dispose();
            con.Close();
        }
