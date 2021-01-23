    using System;
    using System.Collections;
    using System.Windows.Forms;
    using System.IO;
    using Shell32; //Reference Microsoft Shell Controls And Automation on the COM tab.
    using System.Runtime.InteropServices;
    using Microsoft.VisualBasic.FileIO;
    namespace RecyclerCS
    {
      public partial class Form1 : Form
      {
        public Form1() {
          InitializeComponent();
        }
        private Shell Shl;
        private const long ssfBITBUCKET = 10;
        private const int recycleNAME = 0;
        private const int recyclePATH = 1;
    
        private void button1_Click(object sender, System.EventArgs e) {
          string S = "This is text in the file to be restored from the Recycle Bin.";
          string FileName = "C:\\Temp\\Text.txt";
          File.WriteAllText(FileName, S);
          Delete(FileName);
          MessageBox.Show(FileName + " has been moved to the Recycle Bin.");
          if (Restore(FileName))
            MessageBox.Show(FileName + " has been restored");
          else
            MessageBox.Show("Error");
          Marshal.FinalReleaseComObject(Shl);
        }
        private void Delete(string Item) {
          FileSystem.DeleteFile(Item, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
          //Gives the most control of dialogs.
        }
        private bool Restore(string Item) {
          Shl = new Shell();
          Folder Recycler = Shl.NameSpace(10);
          for (int i = 0; i < Recycler.Items().Count; i++) {
            FolderItem FI = Recycler.Items().Item(i);
            string FileName = Recycler.GetDetailsOf(FI, 0);
            if (Path.GetExtension(FileName) == "") FileName += Path.GetExtension(FI.Path);
            //Necessary for systems with hidden file extensions.
            string FilePath = Recycler.GetDetailsOf(FI, 1);
            if (Item == Path.Combine(FilePath, FileName)) {
              DoVerb(FI, "ESTORE");
              return true;
            }
          }
          return false;
        }
        private bool DoVerb(FolderItem Item, string Verb) {
          foreach (FolderItemVerb FIVerb in Item.Verbs()) {
            if (FIVerb.Name.ToUpper().Contains(Verb.ToUpper())) {
              FIVerb.DoIt();
              return true;
            }
          }
          return false;
        }
      }
    }
