     int chkBoxCount = chkboxListWorkTypes.Items.Count;
     foreach (DataRow dr in dtResult.Rows)
     {
        string rowValue = (string)dr["WorkTypeID"];
        for (var i = 0; i < chkBoxCount; i++)
        {
          var chkBox = chkboxListWorkTypes.Items[i];
          if (!chkBox.Selected && chkBox.Value.Equals(rowValue)) 
          {
             chkBox.Selected = true;
          }
        }
     }
</pre>
