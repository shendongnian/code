        private void addTabPage()
        {
            TabItem tc = new TabItem();
            tc.Header = "New page";
            TabControlPages.Items.Insert(TabControlPages.Items.Count - 1, tc); //insert new page            
        }
