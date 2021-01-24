    string sql = "SELECT LastName, AFM, TYPE, CATEGORY, SalePrice, FPA, Quantity, Final_Price " + 
    	"FROM CUSTOMER c " + 
    	"INNER JOIN [ORDER] o ON  c.CUST_ID = o.CUST_ID " + 
    	"INNER JOIN PRODUCT_ORDER p ON o.ID_ORDER = p.ID_ORDER " + 
    	"INNER JOIN STORE s ON  p.K_E = s.KE " + 
    	"WHERE c.LASTNAME =@LastName";
    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("", connect);
    cmd.Parameters.AddWithValue("@LastName", ComboBox1.Text.Tostring());
    System.Data.SqlClient.SqlDataAdapter d2 = new System.Data.SqlClient.SqlDataAdapter(cmd);
