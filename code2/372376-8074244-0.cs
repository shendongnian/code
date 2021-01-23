        protected void MyListBox_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                listObject = sender as ListBox;
                if (listObjct ! = null && !CheckItemInDBorNot(listObject.Text))
                {
                    // This item not exists in Db,
                    // excute sql insert it into Db.
                    Add(listOjbect.Text);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
