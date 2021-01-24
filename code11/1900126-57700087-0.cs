        private void Delete(){
     try
            {
                conn.Open();
    
    
                ColumnView view = gridControl1.FocusedView as ColumnView;
    
                int id = Convert.ToInt32(gridView1.GetDataRow(view.FocusedRowHandle)["product_id"]);
                string query = "UPDATE product SET del =@product_del where product_id= @id";
                int del = 1;
                SqlCommand sc = new SqlCommand(query, conn);
    
                sc.Parameters.AddWithValue("@product_del", del);
                sc.Parameters.AddWithValue("@id", id);
                sc.ExecuteScalar();
                sc.Dispose();
                conn.Close();
            }
    }
 
