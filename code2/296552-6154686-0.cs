    for (var i = 0; i < data.rows.length;i++ ) {
       data.rows[i].c[0].v = new Date(data.rows[i].c[0].v);
    }
    private string getGetJsonString<T>(IEnumerable<dynamic> list, dynamic row) {
    
        string header = "{\"cols\":[";
        PropertyInfo[] props = row.GetType().GetProperties();
        foreach (PropertyInfo p in props)
        {
    
            header += "{\"id\":\"" + p.Name + "\", \"label\":\"" + p.Name + "\",";
            switch (p.PropertyType.Name)
            {
                case "Int32":
                    header += "\"type\":\"number\"";
                    break;
                case "DateTime":
                    header += "\"type\":\"date\"";
                    break;
                default:
                    header += "\"type\":\"string\"";
                    break;
            }
            header += "},";
        }
        header = header.Substring(0, header.Length - 1);
        header += "]";
    
        StringBuilder json = new StringBuilder();
        json.Append(header + ",\"rows\":[");
    
        bool first = true;
        foreach (dynamic a in list)
        {
            string jRow = "{\"c\":[";
            if (first)
                first = false;                    
            else
                jRow = "," + jRow;
    
            foreach (PropertyInfo p in props)
            {
    
                // todo get other fieldtypes from http://code.google.com/apis/chart/interactive/docs/reference.html#dataparam
                switch (p.PropertyType.Name)
                {
                    case "Int32":
                        jRow += "{\"v\":";
                        jRow += p.GetValue(a,null).ToString();
                        jRow += "},";
                        break;
                    case "DateTime":
                        jRow += "{\"v\":\"";
                        DateTime d = ((DateTime)p.GetValue(a, null));
                        //jRow += d.DayOfYear;
                        //jRow += "\\/Date("+d.Ticks+")\\/";
                        jRow += d.ToString("yyyy-MM-dd");
                        //jRow += "new Date(" + d.Ticks+ ")";
                        jRow += "\"},";
                        break; 
                    default:
                        jRow += "{\"v\":\"";
                        jRow += p.GetValue(a,null).ToString();
                        jRow += "\"},";
                        break;
                }
    
            }
            jRow = jRow.Substring(0, jRow.Length - 1);
            json.Append(jRow + "]}");
        }
                
        json.Append("]}");
    
    
        return json.ToString() ;
    }
