    using System;
    using System.Xml;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public static string DataTableToString(DataTable dtData)
    {
    	string sData = null;
    	StringBuilder sBuffer = null;
    	string Token = null;
    
    	int i = 0;
    	int j = 0;
    
    	sBuffer = new StringBuilder();
    	sBuffer.Append(@"<TABLE>");
    
    	sBuffer.Append(@"<TR>");
    	foreach (DataColumn Col in dtData.Columns)
    	{
    		sBuffer.Append(@"<TH ColType='")
    			.Append(Convert.ToString(Col.DataType))
    			.Append(@"'>")
    			.Append(Col.ColumnName.Replace("&", ""))
    			.Append(@"</TH>");
    	}
    	sBuffer.Append(@"</TR>");
    	
    	i = 0;
    	foreach (DataRow rw in dtData.Rows)
    	{
    		sBuffer.Append(@"<TR>");
    
    		j = 0;
    		foreach (DataColumn Col in dtData.Columns)
    		{
    			if (!Convert.IsDBNull(rw[Col.ColumnName]))
    			{
    				Token = Convert.ToString(rw[Col.ColumnName]);
    			}
    			else
    			{
    				Token = null;
    			}
    
    			sBuffer.Append(@"<TD>").Append(Token).Append(@"</TD>");
    
    			j++;
    		}
    
    		sBuffer.Append(@"</TR>");
    
    		i++;
    	}
    	sBuffer.Append(@"</TABLE>");
    	sData = sBuffer.ToString();
    
    	return sData;
    }
    
    public static DataTable StringToDataTable(string sXmlData)
    {
    	DataTable dtData = null;
    	XmlDocument xmlDoc = null;
    	XmlNode RootNode = null;
    	XmlNodeList TRList = null;
    	XmlNodeList THList = null;
    	XmlNodeList TDList = null;
    
    	int i = 0;
    	int j = 0;
    
    	XmlAttribute DataTypeAttrib = null;
    	string sDataType = null;
    	DataColumn Col = null;
    	Type ColType;
    
    	string Token = null;
    
    	DataRow newRw = null;
    
    	xmlDoc = new XmlDocument();
    	xmlDoc.LoadXml(sXmlData);
    
    	RootNode = xmlDoc.SelectSingleNode("/TABLE");
    	if (RootNode != null)
    	{
    		dtData = new DataTable();
    
    		i = 0;
    		TRList = RootNode.SelectNodes("TR");
    		foreach (XmlNode TRNode in TRList)
    		{
    			if (i == 0)
    			{
    				THList = TRNode.SelectNodes("TH");
    				foreach (XmlNode THNode in THList)
    				{
    					DataTypeAttrib = THNode.Attributes["ColType"];
    					sDataType = DataTypeAttrib.Value;
    					ColType = Type.GetType(sDataType);
    					Col = new DataColumn(THNode.InnerText, ColType);
    
    					if (!dtData.Columns.Contains(Col.ColumnName))
    					{
    						dtData.Columns.Add(Col);
    					}
    				}
    			}
    			else
    			{
    				newRw = dtData.NewRow();
    
    				j = 0;
    				TDList = TRNode.SelectNodes("TD");
    				foreach (XmlNode TDNode in TDList)
    				{
    					ColType = dtData.Columns[j].DataType;
    
    					Token = TDNode.InnerText;
    					if (!string.IsNullOrEmpty(Token))
    					{
    						try
    						{
    							newRw[j] = Convert.ChangeType(Token, ColType);
    						}
    						catch
    						{
    							if (ColType == typeof(DateTime))
    							{
    								newRw[j] = DateTime.ParseExact(Token, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
    							}
    						}
    					}
    					else
    					{
    						newRw[j] = Convert.DBNull;
    					}
    
    					j++;
    				}
    
    				dtData.Rows.Add(newRw);
    			}
    
    			i++;
    		}
    	}
    		
    	return dtData;
    }
