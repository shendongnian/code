    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
    	stringBuilder matrix = new stringBuilder();
    	var SemList = (from row in dt.AsEnumerable()                                    
    				  select new
                      {
                       SemName = row.Field<string>("SemName"),
                       SemID = row.Field<string>("SemID")
                      });
    				  
        if (SemList != null)
        {
            Matrix.Append("<select ID='sem_" + dt.Rows[k]["ActualCMID"].ToString() + "' runat='server' width='100px' onchange='" + Server.HtmlEncode("javascript:BindSpecialization('" + dv.ToTable().Rows[k]["ActualCMID"].ToString() + "')").ToString() + "'>");
            Matrix.Append("<option value='0'>---Select---</option>");
            foreach (var sem in SemList)
            {
               Matrix.Append("<option value='" + sem.SemID + "'>" + sem.SemName + "</option>");
            }
            Matrix.Append("</select>");
        }
    	e.Cell.Controls.Add(new LiteralControl(Matrix.ToString()));
    }
