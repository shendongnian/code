        var query = new SPQuery
                                {
                                    Query = string.Format(@"<Where>
                                            <Or>
                                                <Or>
                                                    <Or>
                                                        <Contains>
                                                            <FieldRef Name='{7}' />
                                                            <Value Type='Text'>{3}</Value>
                                                        </Contains>
                                                        <Contains>
                                                            <FieldRef Name='{6}' />
                                                            <Value Type='Text'>{2}</Value>
                                                        </Contains>
                                                    </Or>
                                                    <Contains>
                                                        <FieldRef Name='{5}' />
                                                        <Value Type='Text'>{1}</Value>
                                                    </Contains>
                                                </Or>
                                                <Contains>
                                                    <FieldRef Name='{4}' />
                                                    <Value Type='Text'>{0}</Value>
                                                </Contains>
                                            </Or>
                                    </Where>", "title", "adress", "zipcode", "city", "searchTitle", "searchAdress", "searchZipcode", "searchCity")
                                };
