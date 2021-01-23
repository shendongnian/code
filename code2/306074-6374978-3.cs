     using (SqlConnection conn= new SqlConnection(
               connectionString))
       {
          //You have cmd.Open it should be connection
          conn.Open();
          cmd = new SqlCommand("Select farmername, from cottonpurchase where farmercode=@aa", conn);
          cmd.Parameters.Add("@aa", SqlDbType.Int).Value = TxtFarmerCode.Text;
          dr = cmd.ExecuteReader();
          if (dr.HasRows == false)
          {
               throw new Exception();
          }
          if (dr.Read())
          {
             // textBox1.Text = dr[0].ToString(); Since U r going to give the ID and retrieve in textBox1.
            TxtFarmerName.Text = dr[0].ToString();
            //textBox3.Text = dr[1].ToString();
            //textBox4.Text = dr[2].ToString();
            //textBox7.Text = dr[3].ToString();
            //dateTimePicker1.Text = dr[4].ToString();
            //dateTimePicker2.Text = dr[5].ToString();
            //textBox5.Text = dr[6].ToString();
            }
        }
        catch
        {
             //    lblError = "THE GIVEN ID IS UNAVAILABLE";
        }
        finally
        {
            conn.Close();
        }
       }
