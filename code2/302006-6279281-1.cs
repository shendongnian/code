    private void tvwACH_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvwACH.SelectedNode = e.Node;
            if (Convert.ToInt16(e.Node.Tag) == 3)
            {
                New.Text = "New";
                contextMenu.Items.Remove(New);
                contextMenu.Items.Add(Save);
                contextMenu.Items.Add(Saveas);
                contextMenu.Items.Add(Remove);
                contextMenu.Items.Remove(addEntry);
            }
            if (tvwACH.SelectedNode.Tag == null)
            {
                string str = tvwACH.SelectedNode.Parent.ToString().Substring(10);
                if (str == "BatchHeader")
                {
                    contextMenu.Items.Remove(New);
                    contextMenu.Items.Remove(Remove);
                    contextMenu.Items.Remove(Save);
                    contextMenu.Items.Remove(Saveas);
                    contextMenu.Items.Add(addEntry);
                   
                }
                else
                {
                    contextMenu.Items.Add(New);
                    New.Text = "Add new Batch";
                    contextMenu.Items.Remove(Remove);
                    contextMenu.Items.Remove(Save);
                    contextMenu.Items.Remove(Saveas);
                    contextMenu.Items.Remove(addEntry);
                   
                }
            }
            if (Convert.ToInt16(tvwACH.SelectedNode.Tag) == 1)
            {
                contextMenu.Items.Add(New);
                New.Text = "New";
                contextMenu.Items.Remove(Remove);
                contextMenu.Items.Remove(Saveas);
                contextMenu.Items.Remove(Save);
                contextMenu.Items.Remove(addEntry);
            }
            if (Convert.ToInt16(tvwACH.SelectedNode.Tag) == 2)
            {
                contextMenu.Items.Add(New);
                New.Text = "Add new FileHeader";
                contextMenu.Items.Remove(Remove);
                contextMenu.Items.Remove(Saveas);
                contextMenu.Items.Remove(Save);
                contextMenu.Items.Remove(addEntry);
               
            }
        }
