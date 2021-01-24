    for (int i = lvValid.Items.Count - 1; i >= 0 ; i--)
    {
        if (DateTime.Now.AddDays(-3) > DateTime.Parse(lvValid.Items[i].SubItems[1].Text))
        {
            lvValid.Items[i].Remove();
        }
    }
