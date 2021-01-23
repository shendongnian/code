        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Control> controls = new List<Control>();
                controls.Add(this.txtQty);
                controls.Add(this.txtComment);
                ValidationHelper.ValidateFields(controls);
                //rest of your code
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
