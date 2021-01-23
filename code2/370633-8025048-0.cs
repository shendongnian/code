    private void buttonOk_Click(object sender, EventArgs e)
    {
        if (validateData())
        {
            try
            {
                // Create book instance and assign properties
                Book = new LibraryBook()
                {
                    Title = textBoxTitle.Text,
                    Author = textBoxAuthor.Text,
                    CopyrightYear = Convert.ToInt32(textBoxCopyrightYear.Text)
                };
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "There was an error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
