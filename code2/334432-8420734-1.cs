    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    
    namespace MyApplication.Extensions 
    {
    
        public static class LinqExtenions 
        {
            /// <summary>
            /// 	Groups the elements of a sequence according to a specified firstKey selector 
            ///     function and rotates the unique values from the secondKey selector function into 
            ///     multiple values in the output, and performs aggregations. 
            /// </summary>
            /// <param name="source">The data source for the pivot</param>
            /// <param name="rowKeySelector">A function to derive the key for the rows</param>
            /// <param name="columnKeySelector">A function to derive the key for the columns</param>
            /// <param name="valueSelector">A function to calculate the contents of the intersection element. Usually this is an aggreation function</param>
            /// <param name="firstColumnName">The label to give the first column (row title)</param>
            /// <param name="additionalHeaderSelectors">An optional dictionary of additional rows to use as headers. Typically, this data should be consistent with the row selector since only the first match is taken.</param>
            /// <returns>A datatable pivoted from the IEnumerable source.</returns>
            /// <remarks>
            /// Based on concepts from this article: http://www.extensionmethod.net/Details.aspx?ID=147
            /// </remarks>
            public static DataTable Pivot<TSource, TRowKey, TColumnKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TRowKey> rowKeySelector, Func<TSource, TColumnKey> columnKeySelector, Func<IEnumerable<TSource>, TValue> valueSelector, string firstColumnName = "", IDictionary<string, Func<TSource, object>> additionalHeaderSelectors = null)
            {
                var result = new DataTable();
    
                // determine what columns the datatable needs and build out it's schema
                result.Columns.Add(new DataColumn(firstColumnName));
                var columnNames = source.ToLookup(columnKeySelector);
                foreach (var columnName in columnNames)
                {
                    var newColumn = new DataColumn(columnName.Key.ToString());
                    result.Columns.Add(newColumn);
                }
    
                // if we have a 2nd header row, add it
                if (additionalHeaderSelectors != null)
                {
                    foreach (var additionalHeaderSelector in additionalHeaderSelectors)
                    {
                        var newRow = result.NewRow();
    
                        newRow[firstColumnName] = additionalHeaderSelector.Key;
    
                        foreach (var columnName in columnNames)
                        {
                            newRow[columnName.Key.ToString()] = additionalHeaderSelector.Value(columnName.FirstOrDefault());
                        }
    
                        result.Rows.Add(newRow);
                    }
                }
    
    
                // build value rows
                var rows = source.ToLookup(rowKeySelector);
                foreach (var row in rows)
                {
                    var newRow = result.NewRow();
    
                    // put the key into the first column
                    newRow[firstColumnName] = row.Key.ToString();
    
                    // get the values for each additional column
                    var columns = row.ToLookup(columnKeySelector);
                    foreach (var column in columns) 
                    {
                        newRow[column.Key.ToString()] = valueSelector(column);
                    }
    
                    result.Rows.Add(newRow);
                }
    
                return result;
            }
        }
    }
