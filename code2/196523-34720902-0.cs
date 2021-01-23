    using System;
    using System.Collections.Generic;
    using System.Text;
    //add extra namespaces
    using Code7248.word_reader;
     
    
    namespace testWordRead
    {
        class Program
        {
            private void readFileContent(string path)
            {
                TextExtractor extractor = new TextExtractor(path);
                string text = extractor.ExtractText();
                Console.WriteLine(text);
            }
            static void Main(string[] args)
            {
                Program cs = new Program();
                string path = "D:\Test\testdoc1.docx";
                cs.readFileContent(path);
                Console.ReadLine();
            }
        }
    }
