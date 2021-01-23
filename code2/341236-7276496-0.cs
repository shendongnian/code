    using System;
    using System.IO; 
    
    class Program {
        static void Main( string[] args ) {
            string filePath = @"test.txt";
            string line; 
            string fileContent = "";
            
            if (File.Exists( filePath )) {
                StreamReader file = null;
                try {
                    file = new StreamReader( filePath );
                    while ((line = file.ReadLine()) != null) {
                    	    if (!line.StartsWith(";")){
                    	    	    Console.WriteLine( line );
                    	    	    fileContent += line;	    
                    	    }
                    }
                } finally {
                    if (file != null)
                        file.Close();
                }
            }
        }
    } 
    }
