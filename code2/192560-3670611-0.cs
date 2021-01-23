    foreach ( var item in dt.Rows.Cast<DataRow>().Select(r=> new MyDTO {                 
              category =  CategoryDDL.SelectedItem.ToString(),
              agency =    r["Agency"].ToString(),
              route =     r["Route"].ToString(),
              direction = r["Direction"].ToString(),
              serviceKey= r["Service Key"].ToString(),
              language =  r["Language"].ToString(),
              originalID = GetActiveServiceKeys.Rows[r["Active Service Keys"].ToString()]
              activeServiceKeys =  r["Active Service Keys"].ToString()}
            ))
          
            if (item.originalID!=null)           
               int updateData = askta.UpdateActiveServiceKeys(item);
            else
               int insertData = askta.InsertActiveServiceKeys(item);
