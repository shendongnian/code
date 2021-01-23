    string SQL = "insert into furniture_ProductAccessories(Product_id,Accessories_id,SkuNo,Description1,Price,Discount) values(@Product_id,@Accessories_id,@SkuNo,@Description1,@Price,@Discount)"
    
    SqlParameters[] parameters = new SQLParameters[6];
    parameters[0] = new SqlParameter("@Product_id", SqlDbType.Int, prodid );
    parameters[1] = new SqlParameter("@Accessories_id", SqlDbType.VarChar, strAcc );
    parameters[2] = new SqlParameter("@SkuNo", SqlDbType.VarChar, txtSKUNo);
    parameters[3] = new SqlParameter("@Description1", SqlDbType.VarChar, txtAccDesc.Text);
    parameters[4] = new SqlParameter("@Price", SqlDbType.Money, txtAccPrices.Text);
    parameters[5] = new SqlParameter("@Discount", SqlDbType.Money, txtAccDiscount.Text);
    
    customUtility.ExecuteNonQuery(sql, paramters)
 
      public static bool ExecuteNonQuery(string SQL, SqlParameters[] parameters)
    {
        bool retVal = false;
        using (SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["dbConnect"].ToString()))
        {
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            SqlCommand command = new SqlCommand(SQL, con, trans);
            cmd.parameters.AddRange(parameters);
            try
            {
                command.ExecuteNonQuery();
                trans.Commit();
                retVal = true;
            }
            catch(Exception ex)
            {
                //HttpContext.Current.Response.Write(SQL + "<br>" + ex.Message);
                //HttpContext.Current.Response.End();
            }
            // finally
            //{
                // Always call Close when done reading.
              //  con.Close(); Using already does this, so need for this
            //}
            return retVal;
        }
