    var list = list1.AsQueryable();
    foreach (string str in SearchItems)
    {
         list = list.Where(p => p.Name.Contains(str.ToLower()));
    }
    listBox1.ItemsSource = list.ToList();
