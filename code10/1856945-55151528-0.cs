    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace Demo
    {
    	public static class Utilities
    	{
    		private static char separator = '|';
    
    		public static List<string> ToCSV(this DataSet ds, bool withTypes = false)
    		{    
    			List<string> lResult = new List<string>();
    
    			foreach (DataTable dt in ds.Tables)
    			{
    				StringBuilder sb = new StringBuilder();
    				IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
    												  Select(column => (column.ColumnName + (withTypes ? separator + column.DataType.ToString() : "")));
    				sb.AppendLine(string.Join(separator.ToString(), columnNames));
    
    				foreach (DataRow row in dt.Rows)
    				{
    					IEnumerable<string> fields = row.ItemArray.Select(field => $"{field.ToString().Replace("\"", "\"\"").Replace(Environment.NewLine, " ")}{(withTypes ? separator + "" : "") }");
    					sb.AppendLine(string.Join(separator.ToString(), fields));
    				}
    
    				lResult.Add(sb.ToString());
    			}
    
    			return lResult;
    		}
    
    		public static DataSet CSVtoDataSet(this List<string> collectionCSV, bool withTypes = false) //, char separator = '|')
    		{    
    			var ds = new DataSet();
    
    			foreach (var csv in collectionCSV)
    			{
    				var dt = new DataTable();
    
    				var readHeader = false;
    				var lines = csv.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    
    				foreach (var line in lines)
    				{
    					if (!readHeader)
    					{
    						readHeader = true;
    						List<string> splited = line.Split(separator).ToList();
    
    						for (int i = 0; i < splited.Count; i++)
    						{
    							var columnName = splited[i];
    							var columnType = typeof(string);
    
    							if (withTypes && splited.Count > 1)
    							{
    								i++;
    								if (lines.Count() > 1)
    								{
    									columnType = Type.GetType(splited[i]);
    								}
    							}
    
    							dt.Columns.Add(new DataColumn { ColumnName = columnName, DataType = columnType, AllowDBNull = true });
    						}
    					}
    					else
    					{
    						var splitedRow = line.Split(separator).ToList();
    
    						List<object> currentRow = new List<object>();
    
    						for (int i = 0; i < splitedRow.Count; i++)
    						{
    							if (withTypes && splitedRow.Count > 1)
    							{
    								var inputValue = splitedRow[i];
    								var t = dt.Columns[i / 2].DataType;
    
    								TypeConverter typeConverter = TypeDescriptor.GetConverter(t);
    								object propValue = string.IsNullOrEmpty(inputValue) ? null : typeConverter.ConvertFromString(inputValue);
    
    								currentRow.Add(propValue);
    								i++;//Next (0/2)
    							}
    							else
    							{
    								currentRow.Add(splitedRow[i]);
    							}
    						}
    
    						if (!currentRow.All(x => string.IsNullOrEmpty(x.ToString())))
    							dt.Rows.Add(currentRow.ToArray());
    					}
    				}
    
    				ds.Tables.Add(dt);
    			}
    
    			return ds;
    		}
    	}
    }
