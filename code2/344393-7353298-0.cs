         public static decimal GetDecimal(this SqlDataReader reader, int columnIndex) 
         {    
            if(!reader.IsDBNull(columnIndex))  
                 {      
                 return reader.GetDecimal(colIndex);    
              }
             else
               {
                       return 0; 
             }
           }
