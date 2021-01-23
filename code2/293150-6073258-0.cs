        private void getFilesButton_Click(object sender, EventArgs e)
        {
            filesCheckedListBox.Items.Clear();
            PopulateWithFilesRecursively(directoryTextBox.Text, filesCheckedListBox, string.Empty);
        }
        private static void PopulateWithFilesRecursively(string sourceDirectory, CheckedListBox checkedListBox, string relativeDirectory)
        {
            foreach (string file in Directory.GetFiles(sourceDirectory))
            {
                checkedListBox.Items.Add(Path.Combine(relativeDirectory, Path.GetFileName(file)));
            }
            foreach (string directory in Directory.GetDirectories(sourceDirectory))
            {
                PopulateWithFilesRecursively(directory, checkedListBox, Path.Combine(relativeDirectory, Path.GetFileName(directory)));
            }
        }
