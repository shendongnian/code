        {
            foreach (CheckBox item in list1.Items)
            {
                if (item.IsChecked==true)
                {
                    MessageBox.Show(item.Content.ToString());
                }
            }
        }
