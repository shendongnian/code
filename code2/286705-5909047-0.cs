     protected void dl_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            DataList dl = sender as DataList;
            if (e == null || e.Item == null)
            {
                Trace.Write("dl_ItemCommand", "EventArgs.Item is null");
                throw new Exception("dl_ItemCommand: EventArgs.Item is null");
            }
    
            int selIdx = dl.SelectedIndex;
    
            Trace.Write("dl_ItemCommand", String.Format("{0}: {1}",
                e.CommandName.ToLower(), e.Item.ItemIndex));
            switch (e.CommandName.ToLower())
            {
                case "select":
                    selIdx = e.Item.ItemIndex;
                    break;
                case "unselect":
                    selIdx = -1;
                    break;
            }
    
            if (selIdx != dl.SelectedIndex)
                dl.SelectedIndex = selIdx;
            dl.DataBind();
        }
