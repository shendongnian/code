public Form1()
{
    string path = @"C:\MyPath\";            
    Filecheck NewFileChecker = new Filecheck();
    NewFileChecker.OnUpdateData += (d => UpdateRTBoxJournal(d));
    NewFileChecker.WatchingFile(path, "myFile.txt");
}
public void UpdateRTBoxJournal(string line)
{
    richTextBoxName.Invoke(new MethodInvoker(delegate
    {
    richTextBoxName.Text = line;
    }));
}
And finally in the other class in another file...
public delegate void UpdateData(string data);
class Filecheck
{
    public event UpdateData OnUpdateData;
    public void WatchingFile (string FilePath, string Filter)
    {
        FileSystemWatcher fsw = new FileSystemWatcher();
        fsw.Path = FilePath;
        fsw.Filter = Filter;
        fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite;
        fsw.Changed += OnFileChange;
        fsw.EnableRaisingEvents = true;
    }
    private void OnFileChange(object sender, FileSystemEventArgs e)
    {
        string line;
        try
        {
            using (FileStream file = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(file, Encoding.Default))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    this.OnUpdateData?.Invoke(line);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Une erreur s'est produite." + ex.Message);
        }
    }
}
Thanks again for your anwser.
