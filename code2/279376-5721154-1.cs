    var type = this.GetType();
    var fundNoProperties = type.GetProperties()
        .Where(p => p.Name.StartsWith("FUNDNO"));
    foreach (var info in fundNoProperties)
    {
        string orderNumber = info.Name.Replace("FUNDNO", "");
        var fundTypeInfo = type.GetProperty("FUNDTYPE" + orderNumber);
        if (info.GetValue(this, null).ToString() == "999" &&
            fundTypeInfo.GetValue(this, null).ToString() == "F")
        {
            var currRate = type.GetProperty("CURRATE" + orderNumber);
            return currRate.Name + currRate.GetValue(this, null).ToString();
        }
    }
        
