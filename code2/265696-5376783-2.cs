             for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
             {
                 if (dGV.Columns[j].Visible)
                 {
                      var value = dGV.Rows[i].Cells[j].Value.ToString();
                      var append = value.Contains(",")
                                     ? string.Format("\"{0}\"", value)
                                     : value;
                      stLine = string.Format("{0}{1},", stLine, append) ;
                 }
             }
