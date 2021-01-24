     if (!object.Equals(ds.Tables[0], null))
     {
         if (ds.Tables[0].Rows.Count > 0)
         {
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 htmlTable.Append("<tr>");
                 htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["com_id"] + "</td>");
                 htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["company_name"] + "</td>");
                 htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["openbal"] + "</td>");
                 htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["city"] + "</td>");
                 htmlTable.Append("</tr>");
              }
                 tabledata.Controls.Add(new Literal { Text = htmlTable.ToString() });
         }    
         else
         {
             htmlTable.Append("<tr>");
             htmlTable.Append("<td align='center' colspan='4'>There is no Record.</td>");
             htmlTable.Append("</tr>");
          }
      }
