            string line;
            String Report = "ReportRequest";
            using (StreamReader reader = new StreamReader("file.txt"))          
            using (StreamWriter writer = new StreamWriter("newfile.txt"))
            
                while (reader.ReadLine() != null)                   
                {
                    if (reader.ReadLine().StartsWith(Report))
                    {
                        //writes/starts a new line beginning with ReportRequest
                        writer.WriteLine(line);
                    }
                    else {
                        //appends info to same line (beginning with a space)
                        writer.Write(" " + line);
                    }                       
                    }
