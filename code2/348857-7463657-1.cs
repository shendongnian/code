    var path = Path.Combine(Environment.CurrentDirectory, ListBox2.SelectedItem.ToString());
    
    using (var writer = new StreamWriter(path))
    {
        for (int I = 0; I < ListBox1.Items.Count; I++)
        {
            Text = (SubCategories.Items[I]).ToString();
            writer.WriteLine(Text);
        }
    }
