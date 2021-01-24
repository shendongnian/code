GridView1.DataBind();
I had a problem where even after databind , the result did not show.
Apparently the submit button has a broken PostBackUrl configuration as i was testing another method earlier.
I deleted my button and replaced with a new one , now results are showing properly.
I no longer need to use a storeproc method such as :
using (SqlConnection appCon = new SqlConnection(appdb))
     {
        using (SqlCommand cmd = new SqlCommand("StoreProcedureName", appCon))
        {
             cmd.CommandType = CommandType.StoreProcedure;
             cmd.Parameters.AddWithValue("@EMPLOYEE_ID",empIDTextBox.Text);
             using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
             {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
     }
Thank you everyone.
