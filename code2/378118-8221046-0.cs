            //指定行不存在
            if (dataTable.Rows.Count < (rowIndex + 1))
            {
                throw new Exception("指定行不存在!");
            }
            //DataTable列为空!
            if (dataTable.Columns.Count < 1)
            {
                throw new Exception("DataTable列为空!");
            }
            Type type = obj.GetType();
            PropertyInfo[] pInfos = type.GetProperties();
            try
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    for (int j = 0; j < pInfos.Length; j++)
                    {
                        //全部转换为小写的作用是防止数据库列名的大小写和属性的大小写不一致
                        if (dataTable.Columns[i].ColumnName.ToLower() == pInfos[j].Name.ToLower())
                        {
                            PropertyInfo pInfo = type.GetProperty(pInfos[j].Name);  //obj某一属性对象
                            object colValue = dataTable.Rows[rowIndex][i]; //DataTable 列值
                            #region 将列值赋给object属性
                            if (!Comm_Object.ObjectIsNull(colValue))
                            {
                                if (pInfos[j].PropertyType.FullName == "System.String")
                                {
                                    pInfo.SetValue(obj, Convert.ToString(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Int32")
                                {
                                    pInfo.SetValue(obj, Convert.ToInt32(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Int64")
                                {
                                    pInfo.SetValue(obj, Convert.ToInt64(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Single")
                                {
                                    pInfo.SetValue(obj, Convert.ToSingle(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Double")
                                {
                                    pInfo.SetValue(obj, Convert.ToDouble(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Decimal")
                                {
                                    pInfo.SetValue(obj, Convert.ToDecimal(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Char")
                                {
                                    pInfo.SetValue(obj, Convert.ToChar(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Boolean")
                                {
                                    pInfo.SetValue(obj, Convert.ToBoolean(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.DateTime")
                                {
                                    pInfo.SetValue(obj, Convert.ToDateTime(colValue), null);
                                }
                                //可空类型
                                else if (pInfos[j].PropertyType.FullName == "System.Nullable`1[[System.DateTime, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                                {
                                    pInfo.SetValue(obj, Convert.ToDateTime(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                                {
                                    pInfo.SetValue(obj, Convert.ToDateTime(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Nullable`1[[System.Int32, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                                {
                                    pInfo.SetValue(obj, Convert.ToInt32(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                                {
                                    pInfo.SetValue(obj, Convert.ToInt32(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Nullable`1[[System.Int64, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                                {
                                    pInfo.SetValue(obj, Convert.ToInt64(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Nullable`1[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                                {
                                    pInfo.SetValue(obj, Convert.ToInt64(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Nullable`1[[System.Decimal, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                                {
                                    pInfo.SetValue(obj, Convert.ToDecimal(colValue), null);
                                }
                                else if (pInfos[j].PropertyType.FullName == "System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                                {
                                    pInfo.SetValue(obj, Convert.ToDecimal(colValue), null);
                                }
                                else
                                {
                                    throw new Exception("属性包含不支持的数据类型!");
                                }
                            }
                            else
                            {
                                pInfo.SetValue(obj, null, null);
                            }
                            #endregion
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
