    using System.Collections.Concurrent;
    using System.IO;
    public partial class Form2 : Form
    {
      public string startfiledir { get; private set; }
      public string[] fileContent { get; private set; }
      public string saveFolder { get; private set; }
      public string filePath { get; private set; }
      private ConcurrentDictionary<string, StreamWriter> writers = new ConcurrentDictionary<string, StreamWriter>();
      OpenFileDialog openFileDialog = new OpenFileDialog();
      private void Button1_Click(object sender, EventArgs e)
      {
        this.button1.Enabled = false;
        Refresh();
        openFileDialog.InitialDirectory = startfiledir;
        openFileDialog.Filter = "txt files (*.txt)|*.txt";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;
        openFileDialog.ShowDialog();
        //Get the path of specified file
        filePath = openFileDialog.FileName;
        fileContent = File.ReadAllLines(filePath);
        //show the button again
        this.button1.Enabled = Enabled;
        Refresh();
      }
      private void SplitDatabutton_Click(object sender, EventArgs e)
      {
        //float splitNum = Int32.Parse(numToSplit.Text);
        float splitNum = 100000;
        var Tasks = System.Threading.Tasks.Parallel.For(0, fileContent.Length, (i) =>
        {
          string MyFile = Path.Combine(saveFolder, ((int)(i / ((float)splitNum))).ToString("0000") + ".txt");
          writers.GetOrAdd(MyFile, File.AppendText(MyFile)).WriteLine(fileContent[i]);
        });
        foreach (var writer in writers)
        {
          writer.Value.Close();
        }
      }
    }
