        protected void FilesGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Open the file and display it
            string fullFileName = FilesGrid.SelectedValue.ToString();
            List<string> contents = new List<string>(File.ReadAllLines(fullFileName));
            FileContents.Text = contents.ToString();
        }
