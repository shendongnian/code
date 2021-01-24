    for (int i = lvValid.Items.Count - 1; i >= 0; i--)
    {
        if (DateTime.Now <= DateTime.Parse(lvValid.Items[i].SubItems[1].Text).AddDays(3);
        {
            lvValid.Items[i].Remove();
        }
    }
