       if(System.IO.Directory.Exists("c://gg"))
            {
                System.IO.Directory.CreateDirectory("C:\\gg//");
                System.IO.File.Create("C:\\gg//file.txt");
            }
            else
            {
                Response.Write("ALREADY FOLDER EXIST");
            }
