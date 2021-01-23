    var search = (IEnumerable<MyObject>)MyObjects;
    if (!string.IsNullOrEmpty(txtCity.Text))
    {
        search = search.Where(o => o.City = txtCity.Text);
    }
    if (!string.IsNullOrEmpty(txtEyeColor.Text))
    {
        search = search.Where(o => o.EyeColor = txtEyeColor.Text);
    }
    foreach(var item in search) {item.Warnings++;}
