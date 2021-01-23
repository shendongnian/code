        public static string GetSelectedItems(this ListBox lbox)
        {
            List<string> selectedValues = new List<string>();
            int[] selectedIndeces = lbox.GetSelectedIndices();
            foreach (int i in selectedIndeces)
                selectedValues.Add(lbox.Items[i].Value);
            return String.Join(",",selectedValues.ToArray());
        }
        public static void SetSelectedItems(this ListBox lbox, string[] values)
        {
            foreach (string value in values)
            {
                int index = lbox.FindString(value);
                if(index != -1)
                     lbox.SetSelected(index,true);
            }
        }
        public static void AddListItems(this ListBox lbox, string[] values)
        {
            foreach (string value in values)
            {
                ListItem item = new ListItem(value);
                lbox.Items.Add(item);
            }
        }
