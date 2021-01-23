    var search = (IEnumerable<MyObject>)MyObjectList;
    if (!string.IsNullOrEmpty(txtCity.Text))
    {
        search = search.Where(o => o.City == txtCity.Text);
    }
    if (!string.IsNullOrEmpty(txtEyeColor.Text))
    {
        search = search.Where(o => o.EyeColor == txtEyeColor.Text);
    }
    // similar checks for name or warning level could go here
    foreach(var item in search) {item.Warnings++;}
