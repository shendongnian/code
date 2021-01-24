        Lobbypage lp = new Lobbypage(label1.Text); // u can make the construcor empty
        SqlDataReader reader = cmdnext.ExecuteReader();
        while (reader.Read())
        {
            label1.Text = reader[0].ToString();
            Form2.label2.Text = reader[0].ToString();
            break;
        }
