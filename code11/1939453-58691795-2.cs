        private void Button1_Click(object sender, EventArgs e)
        {
            //Read id from selected item
            int idSelectedItem = (this.dt.SelectedRows[0].DataBoundItem as exampleEntity).Id;
            using (ExampleModel ctxt = new ExampleModel())
            {
                exampleEntity entity = ctxt.exampleEntities.Find(idSelectedItem);
                entity.SomeValue += 42;
                ctxt.SaveChanges();
            }
        }
