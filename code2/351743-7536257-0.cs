    for (int i = 0; i < listBox1.Items.Count; i++)
    {
        var state = (USState)listBox1.Items.GetItemAt(i);
        if (state.ShortName == "AL" && state.LongName == "Alabama")
        {
            listBox1.Items.RemoveAt(i);
            break;
        }
     }
