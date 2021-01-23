    public static DataTable GROUPBY(DataTable Table, DataColumn[] Grouping, string[] AggregateExpressions, string[] ExpressionNames, Type[] Types)
            {
    
                if (Table.Rows.Count == 0)
    
                    return Table;
    
                DataTable table = SQLOps.PROJECT(Table, Grouping);
    
                table.TableName = "GROUPBY";
    
    
    
                for (int i = 0; i < ExpressionNames.Length; i++)
                {
    
                    table.Columns.Add(ExpressionNames[i], Types[i]);
    
                }
    
    
    
                foreach (DataRow row in table.Rows)
                {
    
                    string filter = string.Empty;
    
    
    
                    for (int i = 0; i < Grouping.Length; i++)
                    {
    
                        //Determine Data Type        
    
                        string columnname = Grouping[i].ColumnName;
    
                        object o = row[columnname];
    
                        if (o is string || DBNull.Value == o)
                        {
    
                            filter += columnname + "='" + o.ToString() + "' AND ";
    
                        }
    
                        else if (o is DateTime)
                        {
    
                            filter += columnname + "=#" + ((DateTime)o).ToLongDateString()
    
                                  + " " + ((DateTime)o).ToLongTimeString() + "# AND ";
    
                        }
    
                        else
    
                            filter += columnname + "=" + o.ToString() + " AND ";
    
                    }
    
                    filter = filter.Substring(0, filter.Length - 5);
    
    
    
                    for (int i = 0; i < AggregateExpressions.Length; i++)
                    {
    
                        object computed = Table.Compute(AggregateExpressions[i], filter);
    
                        row[ExpressionNames[i]] = computed;
    
                    }
    
                }
    
                return table;
    
            }
    
     
