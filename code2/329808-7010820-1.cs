     foreach (CloudDBTableList table in cloudDBTableList)
                {                
                   string uri = string.Format(table.URI, "1-Jan-2011");
                   string result  = _dataPullSvcAgent.GetData (baseURI + uri);
                  
                  
                   string tableClassType = namespacePrefix + "." + table.SchemaName + "." + table.TableName + ", " + namespacePrefix;//namespacePrefix is same as assembly name.
                   Type t = Type.GetType(tableClassType);
                   JavaScriptSerializer jsonDeserializer = new JavaScriptSerializer();
                   var L1 = typeof(List<>);
                   Type listOfT = L1.MakeGenericType(t);
                   var objectList = jsonDeserializer.Deserialize(result, listOfT);
                    
                    
                }
