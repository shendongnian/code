    private bool TryGetItem(Guid key, string value, SPList list, out SPListItemCollection items)
       {
           SPQuery query = new SPQuery();
           string @template = @"<Where>
                                    <Eq>
                                        <FieldRef Name='{1}'/>
                                        <Value Type='Text'>{0}</Value>
                                    </Eq>
                                 </Where>";
           query.Query = string.Format(@template, key.ToString("D"), value);
           items = list.GetItems(query);
           return items.Count > 0;
       }
