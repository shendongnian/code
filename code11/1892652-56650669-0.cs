     public bool hasScanCode(string barcode) {
       if (string.IsNullOrWhiteSpace(barcode)) 
         return false;
       //DONE: paramterize queries 
       string query = 
          @"SELECT ticket 
              FROM tickets 
             WHERE linked_barcode = @prm_BarCode";
       using (var conn = new SqlConnection(connection_string_here)) {
         conn.Open();
 
         using (var q = new SqlCommand(conn, query)) {
           //TODO: q.Parameters.Add is a better choice
           q.Parameters.AddWithValue("@prm_BarCode", barcode.Trim()); 
           using (var reader = q.ExecuteReader()) {
             // we read (fetch) at most 1 record
             // if empty cursor - no record with given barcode 
             return reader.Read(); 
           }
         }
       }
     }
