         int count = 0;    
            foreach(string itemListbox2 in listBox2.Items)
            {
                if (itemListbox2.Selected)
                {    
                     foreach(string itemListbox1 in listbox1.Items)
                     {
                       if (itemListbox1.Selected)
                       {
                          if(itemListbox1.Equals(itemListbox2))
                          {
                            count++;
                            break;
                          }
                       }
                    }
                }
            }
