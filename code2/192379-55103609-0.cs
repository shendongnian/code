        using System.Collections;
        private ListBox SortListBox(ListBox oListBox)
        {
            ArrayList oArrayList = new ArrayList();
            foreach (ListItem oListItem in oListBox.Items)
            {
                oArrayList.Add(oListItem);
            }
            oArrayList.Sort();
            oListBox.Items.Clear();
            foreach (ListItem oListItem in oArrayList)
            {
                oListBox.Items.Add(oListItem);
            }
            return oListBox;
        }
