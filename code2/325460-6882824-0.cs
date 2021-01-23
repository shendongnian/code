    List<SearchEntity> results = new List<SearchEntity>();
    var title = tbTitle.Text;
    var adress = tbAdress.Text;
    var city = tbCity.Text;
    var query = new SPQuery()
    {
        Query = string.Format(
            @"
                        <Where>
                            <Or>
                                <Or>
                                    <Contains>
                                        <FieldRef Name=""Title"" />
                                        <Value Type=""Text"">{0}</Value>
                                    </Contains>
                                    <Contains>
                                        <FieldRef Name=""Adress"" />
                                        <Value Type=""Text"">{1}</Value>
                                    </Contains>
                                </Or>
                                <Contains>
                                    <FieldRef Name=""City"" />
                                    <Value Type=""Text"">{2}</Value>
                                </Contains>
                            </Or>
                        </Where>", title, adress, city)
    };
    var items = list.GetItems(query);
    foreach (var item in items)
    {
        var result = new SearchEntity
        {
            title = item.Title,
            adress = (string)item["Adress"],
            city = (string)item["City"],
        };
        results.Add(result);
    }
    return results;
