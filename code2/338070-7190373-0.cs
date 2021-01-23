    var sb = new StringBuilder();
    
    const string ROWBEGIN = "<tr align='left' valign='top'>";
    const string ROWEND = "</tr>";
    const string CELLBEGIN = "<td align='left' valign='top'>";
    const string CELLEND = "</td>";
    
    targetTable.AsEnumerable()
               .Select(row => string.Format("{0}{1}{2}",
                                            ROWBEGIN,
                                            string.Join(string.Empty,
                                                        row.Table.Columns
                                                                 .Cast<DataColumn>()
                                                                 .Select(column => string.Format("{0}{1}{2}",
                                                                                                 CELLBEGIN,
                                                                                                 (row.IsNull(column) ? string.Empty : row[column].ToString()),
                                                                                                 CELLEND))
                                                                 .ToArray()
                                                        ),
                                            ROWEND)
               )
               .ToList()
               .ForEach(y => sb.Append(y));
