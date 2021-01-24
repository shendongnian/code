    public class NewClass
    {
        public string GetFolderPath()
        {
            var openFolderDialog = new OpenFolderDialog();
            if(openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                return openFolderDialog.SelectedPath;
            }   
            return string.Empty;
        }
    }
