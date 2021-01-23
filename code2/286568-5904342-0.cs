        private void SetSelected(int id)
        {
            foreach (ListItem li in list.Items)
            {
                li.Selected = false;
                if (li.Value == id.ToString())
                {
                    li.Selected = true;
                }
            }
        }
