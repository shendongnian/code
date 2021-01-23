    if (!IsPostBack)
    {
        List<ListItem> data = new List<ListItem>();
        using (IDataReader reader = SqlHelper.GetDataReader(sql.ToString()))
        {
            //sb.AppendLine("<div class=\"narrowRes\">Poulation</div><select name=\"populationSelect\" class=\"narrowResSelect\"><option value=\"0\">All populations</option>");
    
            while (reader.Read())
            {
                int pid = reader.IsDBNull(0) ? -1 : reader.GetInt32(0);
                string population = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
    
                population = population.Trim();
                data.Add(new ListItem(population, pid.ToString()));
                //sb.AppendLine(string.Format("<option value=\"{0}\">{1}</option>", pid, population));
            }
        }
        DropDownList1.DataSource = data;
        DropDownList1.DataBind();
    }
