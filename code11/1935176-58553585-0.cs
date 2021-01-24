    `try
            {
                var fromDate = resource.StartDate.ToString("yyyy-MM-dd") + " 00:00:00";
                var toDate = resource.EndDate.ToString("yyyy-MM-dd") + " 23:59:59";
                string connectionstring = "Server=dbwithriderinstance.crefat3b9j9c.ap-southeast-1.rds.amazonaws.com;Database=dborderstage;User=stagging_su_production_s;Password=85s2!892Stfe7";
                using (MySqlConnection con = new MySqlConnection(connectionstring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetChargesFromToDateV2", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);
                        using (MySqlDataAdapter dbr = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            dbr.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex) { Console.Write(ex); throw ex; }
        }`
