            string output = string.Empty;
            int counter = 0;
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("c:\\test.html");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(reg.Replace(line, ""));
                counter++;
            }
            file.Close();
            Console.Read();
