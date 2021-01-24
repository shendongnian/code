        public DataTable GetDataTableFromListItemCollection(ListItemCollection listItems)
        {
            DataTable dt = new DataTable();
            foreach (var field in listItems[0].FieldValues.Keys)
            {
                dt.Columns.Add(field);
            }
            foreach (var item in listItems)
            {
                DataRow dr = dt.NewRow();
                foreach (var obj in item.FieldValues)
                {
                    if (obj.Value != null)
                    {
                        string key = obj.Key;
                        string type = obj.Value.GetType().FullName;
                        if (type == "Microsoft.SharePoint.Client.FieldLookupValue")
                        {
                            dr[obj.Key] = ((FieldLookupValue)obj.Value).LookupValue;
                        }
                        else if (type == "Microsoft.SharePoint.Client.FieldUserValue")
                        {
                            dr[obj.Key] = ((FieldUserValue)obj.Value).LookupValue;
                        }
                        else if (type == "Microsoft.SharePoint.Client.FieldUserValue[]")
                        {
                            FieldUserValue[] multValue = (FieldUserValue[])obj.Value;
                            foreach (FieldUserValue fieldUserValue in multValue)
                            {
                                dr[obj.Key] += "&" + fieldUserValue.LookupId + "=" + fieldUserValue.LookupValue;
                            }
                        }
                        else if (type == "Microsoft.SharePoint.Client.FieldLookupValue[]")
                        {
                            FieldLookupValue[] multValue = (FieldLookupValue[])obj.Value;
                            foreach (FieldLookupValue fieldLookupValue in multValue)
                            {
                                dr[obj.Key] += "&" + fieldLookupValue.LookupId + "=" + fieldLookupValue.LookupValue;
                            }
                        }
                        else if (type == "System.DateTime")
                        {
                            if (obj.Value.ToString().Length > 0)
                            {
                                var date = obj.Value.ToString().Split(' ');
                                if (date[0].Length > 0)
                                {
                                    dr[obj.Key] = date[0];
                                }
                            }
                        }
                        else
                        {
                            dr[obj.Key] = obj.Value;
                        }
                    }
                    else
                    {
                        dr[obj.Key] = null;
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
