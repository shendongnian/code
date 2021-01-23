    namespace DBTest1 {
      public partial class Form1 : Form {
      const readonly string MYDATABASE = "\\Application Data\\DBTest1\\sqlce.db";
      private void Form1() {
        InitializeComponent();
        CreateIfNotThere(DBTest1.Properties.Resources.sqlcedb, MYDATABASE);
      }
      void CreateIfNotThere(object data, string filename) {
        if (String.IsNullOrEmpty(filename)) {
          filename = string.Format(@"{0}{1}{2}",
          Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
          Path.DirectorySeparatorChar, "sqlCe.db");
        }
        if (data != null) {
          byte[] array = (byte[])data;
          FileInfo file = new FileInfo(filename);
          if (!file.Exists) {
            using (FileStream fs = file.Create()) {
              fs.Write(array, 0, array.Length);
            }
          }
        }
      }
      // other code
    }
