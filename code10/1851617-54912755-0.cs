            string query3 = "SELECT Quantity FROM Supplier WHERE [Supplier ID]='" + supplierid + "'";
            string query4 = "SELECT Quantity FROM Supplier WHERE [Book ID] = '" + bookid + "'";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            SqlCommand cmd4 = new SqlCommand(query4, con);
            con.Open();
            double temporaryquantity = Convert.ToDouble( cmd3.ExecuteScalar());
            double temporaryquantitystocks = Convert.ToDouble(cmd4.ExecuteScalar());
            double totalcostforstocks = (temporaryquantitystocks - temporaryquantity + quantity) * buyingpriceperbook;
