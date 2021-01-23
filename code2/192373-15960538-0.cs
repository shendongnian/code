        private void SortListBox(ListBox listBox)
        {
            SortedList<string, string> list = new SortedList<string, string>(); 
            foreach (ListItem i in listBox.Items) {
                    list.Add(i.Text, i.Value);
            } 
            listBox.Items.Clear();
            foreach(KeyValuePair<string, string> i in list){
                listBox.Items.Add(new ListItem(i.Key, i.Value)); 
            }
        }
