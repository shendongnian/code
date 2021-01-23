        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyEntity newEnt = new MyEntity();
            newEnt = (MyEntity)MyEntityBindingSource.Current;
            ctx.AddToAuthors(newEnt);
        }
        private void MyEntityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                MyEntityBindingSource.EndEdit();
                ctx.SaveChanges();
                ctx.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
