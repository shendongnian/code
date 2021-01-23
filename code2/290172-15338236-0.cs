    List<object> list = new List<object>();
            foreach (object o in myComboBox.Items)
                {
                if (!list.Contains(o))
                    {
                    list.Add(o);
                    }
                }
            myComboBox.Items.Clear();
            myComboBox.ItemsSource=list.ToArray();
