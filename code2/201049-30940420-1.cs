    public static List<string> GetCompletionList(string prefixText, int count)  
        {  
            return AutoFillProducts(prefixText);  
      
        }  
      
        private static List<string> AutoFillProducts(string prefixText)  
        {  
            using (SqlConnection con = new SqlConnection())  
            {  
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;  
                using (SqlCommand com = new SqlCommand())  
                {  
                    com.CommandText = "select ProductName from ProdcutMaster where " + "ProductName like @Search + '%'";  
                    com.Parameters.AddWithValue("@Search", prefixText);  
                    com.Connection = con;  
                    con.Open();  
                    List<string> countryNames = new List<string>();  
                    using (SqlDataReader sdr = com.ExecuteReader())  
                    {  
                        while (sdr.Read())  
                        {  
                            countryNames.Add(sdr["ProductName"].ToString());  
                        }  
                    }  
                    con.Close();  
                    return countryNames;  
                }  
            }  
        }  
    
    
    Now:create a stored Procedure that fetches the Product details depending on the selected product from the Auto Complete Text Box.
    
    Create Procedure GetProductDet  
    (  
    @ProductName varchar(50)    
    )  
    as  
    begin  
    Select BrandName,warranty,Price from ProdcutMaster where ProductName=@ProductName  
    End   
    
    Create a funstion name to get product details ::
    
    private void GetProductMasterDet(string ProductName)  
        {  
            connection();  
            com = new SqlCommand("GetProductDet", con);  
            com.CommandType = CommandType.StoredProcedure;  
            com.Parameters.AddWithValue("@ProductName", ProductName);  
            SqlDataAdapter da = new SqlDataAdapter(com);  
            DataSet ds=new DataSet();  
            da.Fill(ds);  
            DataTable dt = ds.Tables[0];  
            con.Close();  
            //Binding TextBox From dataTable  
            txtbrandName.Text =dt.Rows[0]["BrandName"].ToString();  
            txtwarranty.Text = dt.Rows[0]["warranty"].ToString();  
            txtPrice.Text = dt.Rows[0]["Price"].ToString();   
        }
    
    Auto post back should be true 
    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    
    NOw ,Just call this function 
    
    protected void TextBox1_TextChanged(object sender, EventArgs e)  
      {  
          //calling method and Passing Values  
          GetProductMasterDet(TextBox1.Text);  
      } 
    
        enter code here
    
    EnD :)
