    using System.Windows.Forms;
    [STAThread]
    static void Main(string[] args)
    {
        string fileName = SelectFileDialog();
        Console.WriteLine(fileName);
        Console.ReadKey();
    }
    static string SelectFileDialog()
    {
        using (var ofd = new OpenFileDialog() {
            RestoreDirectory = true,
            Title = "Select a File"
        })
        {
            if (ofd.ShowDialog() == DialogResult.OK) {
                return ofd.FileName;
            }
            return string.Empty;
        };
    }
