     private void CheckButtons()
        {
        
            if (cbList.SelectedItem != null)
            {
                this.btnModify.Enabled = true;
                this.btnRemove.Enabled = true;
            }
            else
            {
                this.btnModify.Enabled = false;
                this.btnRemove.Enabled = false;
            }
        }
