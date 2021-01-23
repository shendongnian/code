     public string GenerateQuery(IList<CamlQueryElements> lstOfElement)
        {
            StringBuilder queryJoin = new StringBuilder();
            string query = @"<{0}><FieldRef Name='{1}' /><Value {2} Type='{3}'>{4}</Value></Eq>";
            if (lstOfElement.Count > 0)
            {
                int itemCount = 0;
                foreach (CamlQueryElements element in lstOfElement)
                {
                    itemCount++;
                    string date = string.Empty;
                    // Display only Date
                    if (String.Compare(element.FieldType, "DateTime", true) == 0)
                        date = "IncludeTimeValue='false'";
                    queryJoin.AppendFormat(string.Format(query, element.ComparisonOperators,
                                    element.FieldName, date, element.FieldType, element.FieldValue));
                    if (itemCount >= 2)
                    {
                        queryJoin.Insert(0, string.Format("<{0}>", element.LogicalJoin));
                        queryJoin.Append(string.Format("</{0}>", element.LogicalJoin));
                    }
                }
                queryJoin.Insert(0, "<Where>");
                queryJoin.Append("</Where>");
            }
            return queryJoin.ToString();
        }
