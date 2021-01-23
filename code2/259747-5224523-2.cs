    for (int i = 0; i < 5; i++)
    {
        checkedBoxIte ite = new checkedBoxIte();
        ite.MyString = i.ToString();
        item.Add(ite);
    }
    dataGrid1.ItemsSource = item;
