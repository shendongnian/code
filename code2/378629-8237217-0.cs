        try
        {
            List<ExplorerItem> list = new List<ExplorerItem>();
            for (int i = 0; i < lbl.Length; i++) // lbl = string array with items
            {
                var item = new ExplorerItem();
                item.title = lbl[i].Name;
                list.Add(item);
            }
            BeginInvoke((MethodInvoker)delegate
            {
                explorerList = list;
                dgvObjectExplorer.RowCount = explorerList.Count;
                dgvObjectExplorer.Invalidate();
            }); 
        }
        catch (Exception e) { MessageBox.Show(e.ToString(); }
