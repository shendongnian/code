    private DataTable getAllList()
            {
                string constr = ConfigurationManager.ConnectionStrings["RConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT EmpId, gender, EmpName, pOnHold FROM Employee  WHERE EmpId= '"+ AnyVariable + "' ORDER BY EmpName"))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            dt.Columns[0].ColumnName = "Employee Id";
                            dt.Columns[1].ColumnName = "Gender";
                            dt.Columns[2].ColumnName = "Employee Name";
                            dt.Columns[3].ColumnName = "On Hold";
                           
                            return dt;
                        }
                    }
                }
            }
