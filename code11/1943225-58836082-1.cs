c#
String query = "UPDATE Table_sagemcom SET Contents='" + textBox6.Text + "' WHERE Variable='" + comboBox5.Text + "'";
and your code really risky, you may use parameters like this, dont use string and convert your value to float :
c#        
static void Main(string[] args)
        {
            var ConnectionString = "YOUR CONNECTION STRING";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                String query = "UPDATE Table_sagemcom SET Contents=@contents WHERE Variable=@variable";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Add("@contents", SqlDbType.Float).Value = Convert.ToDouble(textBox6.Text);
                    cmd.Parameters.Add("@variable", SqlDbType.NVarChar).Value = comboBox5.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
        }
