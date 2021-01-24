    protected void button1_Click(object sender, EventArgs e)
    {
          string query = "SELECT * FROM approved WHERE tm = @tm";
          Button btn = (Button)sender;
          string condition = string.Empty;
          string condition1 = string.Empty;
          condition = string.Format("'{0}'", string.Join("','", ddlstatus.Items.Cast<ListItem>()
                                     .Where(i => i.Selected)
                                     .Select(i => i.Value)
                                     .ToList()));
          condition1 = string.Format("'{0}'", string.Join("','", ddlskill.Items.Cast<ListItem>()
                                     .Where(i => i.Selected)
                                     .Select(i => i.Value)
                                     .ToList()));
           if (!string.IsNullOrEmpty(condition) && condition != "''")
           {
                query += string.Format(" AND status IN ({0})", condition);
           }
           if (!string.IsNullOrEmpty(condition1) && condition1 != "''")
           {
               query += string.Format(" AND skill IN ({0})", condition1);
           }
    
           var q = query;
    
           gdvTM.DataSource = GetDataTable(q);
           gdvTM.DataBind();
      }
