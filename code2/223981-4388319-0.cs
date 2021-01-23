    public static void ToCsv(Stream stream, DataTable dataTable, bool includeColumnHeaders, char valueDelimiter, char textQualifier, string rowDelimiter)
        {
            StreamWriter sw = new StreamWriter(stream);
            string valueFormatString = (textQualifier + "{0}" + textQualifier).Trim();
            if (includeColumnHeaders)
            {  
                for(int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sw.Write(String.Format(valueFormatString, dataTable.Columns[i].ColumnName.Replace(textQualifier.ToString(), textQualifier.ToString() + textQualifier.ToString())));
                    if (i != dataTable.Columns.Count - 1)
                        sw.Write(valueDelimiter);
                }
                sw.Write(rowDelimiter);
            }
            for(int i = 0; i < dataTable.Rows.Count; i++)            
            {
                for (int j = 0; j < dataTable.Rows[i].ItemArray.Length; j++)
                {
                    sw.Write(String.Format(valueFormatString, dataTable.Rows[i][j].ToString().Replace(textQualifier.ToString(), textQualifier.ToString() + textQualifier.ToString())));
                    
                    if(j != dataTable.Rows[i].ItemArray.Length - 1)
                        sw.Write(valueDelimiter);
                }
                sw.Write(rowDelimiter);
            }
            sw.Flush();
        }
