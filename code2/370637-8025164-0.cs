        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                try
                {
                    ----> LibraryBook book = new LibraryBook(); <----- this a private book of this method. 
                    book.Title = textBoxTitle.Text; 
                    book.Author = textBoxAuthor.Text;
                    book.CopyrightYear = Convert.ToInt32(textBoxCopyrightYear.Text);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "There was an error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
