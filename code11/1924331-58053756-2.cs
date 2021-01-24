    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    
    namespace TestAppWithService.Models
    {
        // This is for custom database functions for services
    
        public class MyData
        {
            static string LastErrorMsg = string.Empty;
            public static List<DropDownOption> CalcSelectDDSizeAndTilesPerBoxAll(IConfiguration config)
            {
                Boolean HasErrors = false;
                var retval = new List<DropDownOption>();
    
                string dbconn = config.GetConnectionString("DefaultConnection");
                
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    using (SqlCommand cmd = new SqlCommand("CalcSelectDDSizeAndTilesPerBoxAll", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 30;
                        try
                        {
                            conn.Open();
                            using (SqlDataReader r = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                if (r.HasRows)
                                {
                                    while (r.Read())
                                    {
                                        DropDownOption ddo = new DropDownOption();
                                        ddo.value = r["SizeAndNumInBox"].ToString();
                                        ddo.text = r["Descr"].ToString();
                                        retval.Add(ddo);
                                    }
                                }
                            }
                            LastErrorMsg = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            LastErrorMsg = ex.Message;
                            HasErrors = true;
                        }
                    }
                    if (!HasErrors)
                    {
                        return retval;
                    }
                    else
                    {
                        return new List<DropDownOption>(); //just an empty list returned
                    }
                }
            }
        }
    }
