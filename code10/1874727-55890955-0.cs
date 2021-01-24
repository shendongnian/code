    public class FileSelectorBaseForm : Form
    {
        protected Dictionary<string, string> Files = new Dictionary<string, string>();
        protected virtual void AddElementToForm(Size size, Point location, string controlName, string text)
        {
            Button newSource = new Button();
            newSource.Size = size;
            newSource.Location = location;
            newSource.Name = controlName;
            newSource.Text = text;
            newSource.Click += delegate { ShowFileSelector(newSource.Name); };
            Controls.Add(newSource);
        }
        protected virtual void ShowFileSelector(string source)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV-Files(*.csv)|*.csv";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Files.Add(source, fileDialog.FileName);
            }
        }
    }
