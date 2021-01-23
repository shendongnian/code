    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string destPath = @"C:\foo\Dwarf Fortess\eggCreatures.txt";
                FileInfo fiDest = new FileInfo(destPath);
                DirectoryInfo diDF = new DirectoryInfo(@"C:\foo\Dwarf Fortress");
                var files = from FileInfo f in diDF.GetFiles("*.txt")
                    where f.Name != fiDest.Name
                    select f
                foreach(FileInfo fiRead in files) 
                {
                // create reader & open file
                    string filePath = @"C:\foo\Dwarf Fortess\creature_domestic.txt";
                    string line;
                    // 
                    TextReader tr = fiRead.OpenText();
                    TextWriter tw = new StreamWriter(destPath);
        
                    // read a line of text
                    while ((line = tr.ReadLine()) != null) 
                    {
        
                                if (line.Contains("[CREATURE:"))
                                {
                                    tw.WriteLine(line);
                                }
                                if(line.Contains("[LAYS_EGGS]"))
                                {
                                    tr.ReadLine();
                                    tr.ReadLine();
                                    tr.ReadLine();
                                    tw.WriteLine(tr.ReadLine());
                                    tw.WriteLine(tr.ReadLine());
                                }
    
    
                    }
    
                    // close the stream
                    tr.Close();
                    tw.Close();
                }
            }
        }
    }
