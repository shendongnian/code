    CheckedListBox.CheckedItemCollection s= checkedListBox1.CheckedItems;
            List<object> ns = new List<object>();
            foreach (object ob in s)
            {
                ns.Add(ob);
            }
            listBox1.Items.AddRange(ns.ToArray());
            
