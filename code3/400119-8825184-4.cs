    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    namespace DL
    {
    public class DLQuickSerch
    {
        List<Common.CommonPersonSerchResult> SerchResult = new List<Common.CommonPersonSerchResult>();
        public DLQuickSerch(string Item)
        {
            SqlConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=Khane;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "QuickSerch";
            SqlParameter item = new SqlParameter("item", SqlDbType.NVarChar, 300);
            item.Value = Item;
            command.Parameters.Add(item);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Common.CommonPersonSerchResult res = new Common.CommonPersonSerchResult();
                res.ID = (int)reader.GetValue(0);
                res.FirstName = reader.GetValue(1).ToString();
                res.LastName = reader.GetValue(2).ToString();
                res.FatherName = reader.GetValue(3).ToString();
                res.NationalCode = (int)reader.GetValue(4);
                res.ShenasnameCode = (int)reader.GetValue(5);
                res.BirthDate = reader.GetValue(6).ToString();
                res.State = reader.GetValue(7).ToString();
                res.City = reader.GetValue(8).ToString();
                res.Address = reader.GetValue(9).ToString();
                res.PostalCode = reader.GetValue(10).ToString();
                res.SportType = reader.GetValue(11).ToString();
                res.SportStyle = reader.GetValue(12).ToString();
                res.RegisterType = reader.GetValue(13).ToString();
                res.Ghahremani = reader.GetValue(14).ToString();
                SerchResult.Add(res);
            }
            connection.Close();
        }
        public List<Common.CommonPersonSerchResult> GetQuickSerchResult()
        {
            return SerchResult;
        }
    }
    }
