    class Class1
    {
        static void Main(string[] args)
        { 
              SqlConnection con=new SqlConnection(<connectionstring>);           
              SqlCommand cmd = new SqlCommand("select * from Student", con);
              SqlDataAdapter ad = new SqlDataAdapter(cmd);
              DataSet ds=new DataSet();
              ad.Fill(ds);
              for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
              {
                  try
                  {
                      DataRow r = ds.Tables[0].Rows[i];
                      Console.WriteLine(r.Field<Int32>(0));
                      Console.WriteLine(r.Field<String>(1));
                      Console.WriteLine(r.Field<String>(2));
                      Console.WriteLine(r.Field<Decimal>(3));
                      Console.WriteLine(r.Field<Int16>(4));
                     
                  }
                  catch (Exception ex)
                  {
                      Console.WriteLine(ex);
                  }
              }
              Console.ReadKey();
        }
    }
