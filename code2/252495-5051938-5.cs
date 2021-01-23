     int chkBoxCount = chkboxListWorkTypes.Items.Count;
     for (var i = 0; i < chkBoxCount; i++)
     {
       var chkBox = chkboxListWorkTypes.Items[i];
       if (chkBox.Selected) continue;
       foreach (DataRow dr in dtResult.Rows)
       {
          string rowValue = (string)dr["WorkTypeID"];
          if (string.Equals(chkBox.Value, rowValue, StringComparison.OrdinalIgnoreCase)) 
          {
             chkBox.Selected = true;
             break;
          }
       }
     }
</pre>
