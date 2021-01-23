    checkedListBox1.Items.Add("test");
    checkedListBox1.ItemCheck += new ItemCheckEventHandler(checkedListBox1_ItemCheck);
        
    ....
        
    void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        Console.WriteLine(((CheckedListBox)sender).Name + " is the father of item nr: " + e.Index);
        Console.WriteLine("The value of element nr " + e.Index + " is " + ((CheckedListBox)sender).Items[e.Index].ToString());
    }
