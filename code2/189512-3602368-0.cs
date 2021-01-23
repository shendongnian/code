    for(int i  = dtResult.Rows.Count; i >= 0; i--)
    {
         foreach(object email in emails)
         {
              if(email.ToString().ToUpper() == dtResult[i].ToString().ToUpper())
              {
                   dtResult.Rows.Remove(dtResult.Rows[i]);
                   dtResult.AcceptChanges();
              }
         }
    }
