    private void OnLoad(object sender, System.EventArgs e) 
    {          
           ListCategories();
    }
    private void ListCategories()
    {
     sqlCon = new SqlConnection();
     sqlCon.ConnectionString = Common.GetConnectionString();
     cmd = new SqlCommand();
     cmd.Connection = sqlCon;
     cmd.CommandType = CommandType.Text;
     cmd.CommandText = "SELECT * FROM Categories";
     sqlDa = new SqlDataAdapter();
     sqlDa.SelectCommand = cmd;
     ds = new DataSet();
     try
     {
         sqlDa.Fill(ds, "Category");
         DataRow nRow = ds.Tables["Category"].NewRow();
         nRow["CategoryName"] = "List All";
         nRow["CategoryID"] = "0";
         ds.Tables["Category"].Rows.InsertAt(nRow, 0);
         //Binding the data to the combobox.
          cmbCategory.DataContext = ds.Tables["Category"].DefaultView;
        
        //To display category name (DisplayMember in Visual Studio 2005)
          cmbCategory.DisplayMemberPath = 
              ds.Tables["Category"].Columns["CategoryName"].ToString();
        //To store the ID as hidden (ValueMember in Visual Studio 2005)
          cmbCategory.SelectedValuePath = 
              ds.Tables["Category"].Columns["CategoryID"].ToString();
      }
      catch (Exception ex)
      {
          MessageBox.Show("An error occurred while loading categories.");
      }
      finally
      {
          sqlDa.Dispose();
          cmd.Dispose();
          sqlCon.Dispose();
      }
    }
       
