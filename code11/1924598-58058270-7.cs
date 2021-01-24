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
        int splitNum = 100;
        int chunks = (int)(fileContent.Length / (float)splitNum);
        var Tasks = Parallel.For(0, chunks, (i) =>
        {
          string MyFile = Path.Combine(savePath, i.ToString("0000") + ".txt");
          using (var W = File.AppendText(MyFile))
          {
            for (int j = i * splitNum; j < (i + 1) * splitNum; j++)
              W.WriteLine(fileContent[j]);
          }       
        });
      }
    }
