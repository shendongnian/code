    class myListBox
        {
            public ListBox myList;
            
            public myListBox()
            {
                myList = new ListBox();
            }
            
            public void listClear()
            {
                if (myList.Items.Count > 0)
                {
                    myList.SelectedIndex = 0;
                }
                myList.Items.Clear();
            }
    
        }
