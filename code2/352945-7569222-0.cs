            string displayedText;
            DataRowView drw = null;
            foreach (var item in comboBox1.Items)
            {
                drw = item as DataRowView;
                displayedText = null;
                if (drw != null)
                {
                    displayedText = drw[comboBox1.DisplayMember].ToString();
                }
                else if (item is string)
                {
                    displayedText = item.ToString();
                }
            }
