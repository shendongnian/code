         If you are looking to copy all the text files in one folder to merge and copy to           another folder,you can do this to achieve that
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace HowToCopyTextFiles
      {
      class Program
      {
      static void Main(string[] args)
      {
       string mydocpath=Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);     
       StringBuilder sb = new StringBuilder();
        foreach (string txtName in Directory.GetFiles(@"D:\Links","*.txt"))
        {
        using (StreamReader sr = new StreamReader(txtName))
        {
        sb.AppendLine(txtName.ToString());
        sb.AppendLine("= = = = = =");
        sb.Append(sr.ReadToEnd());
        sb.AppendLine();
        sb.AppendLine();   
        }     
        }
            using (StreamWriter outfile=new StreamWriter(mydocpath + @"\AllTxtFiles.txt"))
            {    
            outfile.Write(sb.ToString());
            }   
        }
    }
}
