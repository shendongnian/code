                int CurrentIndex = StaticVariables.MyListView.GetPlaylistCurrentIndex();
                int count = StaticVariables.MyListView.GetPlaylistCount();
                for (int i = 0; i < CurrentIndex; i++)
                {
                    OLVListItem item = mainForm.MyListView.GetItem(i);
                    item.BackColor = Color.FromArgb(35, 35, 35);
                }
                for (int i = CurrentIndex; i < count; i++)
                {
                    OLVListItem item = mainForm.MyListView.GetItem(i);
                    item.BackColor = Color.FromArgb(18, 18, 18);
                }
                OLVListItem item2 = mainForm.MyListView.GetItem(CurrentIndex);
                item2.BackColor = Color.DarkGreen;
                mainForm.MyListView.Refresh();
