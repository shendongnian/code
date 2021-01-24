    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderPath = folderDialog.SelectedPath;
                //Use folder path
            }
            else
            {
                //Operation aborted by the user
            }
        }
    }
