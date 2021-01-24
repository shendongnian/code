    try
            {
                connn.Open();
                crmd = new SqlCommand("Select * From a_table_in_the_database", connn);
                readdr = crmd.ExecuteReader();
                DataSet ds = new DataSet();                
                DataTable dt = new DataTable();
                dt.Load(readdr);                
                realdatagrid.ItemsSource = dt.DefaultView;
                connn.Close();
    
                //writing the xml file                
                TextWriter write = new StreamWriter(@"C:\XML\see.xml");
                dt.WriteXml(write);
            }
            catch (Exception ex)
            {
                notify.IsOpen = true;
                showing.Text = ex.Message;
            }      
   
