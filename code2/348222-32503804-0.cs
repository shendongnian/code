            for (int i = 0; i < usedDatesList.Items.Count; i++)
            {
                for (int j = 0; j < usedDatesList.Items[i].SubItems.Count; j++)
                {
                    MessageBox.Show(usedDatesList.Items[i].SubItems[j].Text);
                }
            }
