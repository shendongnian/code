    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using Microsoft.VisualBasic.FileIO;
    namespace RestoreFromRecycle
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
          
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        	string TextFile = "D:\\Temp\\Text.txt";
    	    string TextForFile = "This is text for the TextFile.";
    	    File.WriteAllText(TextFile, TextForFile);
    	    FileSystem.DeleteFile(TextFile, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
    	    if (FindFileInRecycleBin(TextFile))
    	    {
    	      Console.WriteLine("File Restored" + " " + File.ReadAllText(TextFile));
    	    }
        }
        public bool FindFileInRecycleBin(string FileName)
        {
    	    foreach (string D in Directory.GetDirectories(Path.GetPathRoot(FileName)))
    	    {
    	      if (D.ToUpper().Contains("RECYCLE"))
    	      {
    		      foreach (string DSub in Directory.GetDirectories(D))
    		      {
    		        foreach (string F in Directory.GetFiles(DSub))
    		        {
    			        if (Path.GetFileName(F).Substring(0, 2) == "$I")
    			        {
    			          byte[] FileData = File.ReadAllBytes(F);
    			          int I, C;
    			          StringBuilder SB = new StringBuilder();
    			          I = 24;
    			          do
    			          {
    				          C = FileData[I];
    				          if (C == 0)
    				          {
    					          break;
    				          }
    				          SB.Append((char)(C));
    				          I += 2;
    			          } while (true);
    			          if (SB.ToString() == FileName)
    			          {
                      File.Copy(F.Replace("\\$I", "\\$R"), FileName);
    				          return true;
    			          }
    			        }
    		        }
    		      }
    	      }
    	    }
    	    return false;
          }
      }
    }
