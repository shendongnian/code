    namespace XY
    {
        public class HelperClass
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
    }
