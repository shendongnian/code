            System.Collections.Specialized.StringCollection filePath = new
                                       System.Collections.Specialized.StringCollection();
            if (listView1.SelectedItems.Count > 0)
            { 
                filePath.Add(listView1.SelectedItems[0].Text);
                DataObject dataObject = new DataObject();
                dataObject.SetFileDropList(filePath);
                listView1.DoDragDrop(dataObject, DragDropEffects.Copy);
            }
        }
