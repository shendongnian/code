    using System;
    using System.IO;
    class Program {
        static void Main() {
            // The name of the file
            const string fileName = "test.txt";
            // Create new FileInfo object and get the Length.
            FileInfo f = new FileInfo(fileName);
            long size = f.Length;
            if(size == 0) {
                /* do something */
            } else {
                /* do something */
            }
         }
    }
