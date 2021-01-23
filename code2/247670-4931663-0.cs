     int count = 0;    
        foreach(string itemListbox2 in listBox2.SelectedItems)
        {
            foreach(string itemListbox1 in listbox1.SelectedItems)
            {
                if(itemListbox1.Equals(itemListbox2))
                {
                    count++;
                    break;
                }
            }
        }
