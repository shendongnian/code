    var data = (from x in xEl3.Descendants(nsPriceHr + "HOEP")
        orderby System.Convert.ToDouble(x.Element(nsPriceHr + "Price").Value) descending 
        select new HourPrice
        {
            Hour = System.Convert.ToInt32(x.Element(nsPriceHr + "Hour").Value),
            Price = System.Convert.Double(x.Element(nsPriceHr + "Price").Value)
        })
        .ToList();
