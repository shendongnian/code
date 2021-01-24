    private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from Clienti where email='" + textBox1.Text + "' and Parola='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                client.email = textBox1.Text;
                this.Hide();
                Form4 ssss = new Form4();
                ssss.Show();
            }
            else MessageBox.Show("verifica datele");
        }
