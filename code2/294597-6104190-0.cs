            string s = System.IO.File.ReadAllText("myfile.txt");
            bool inbrackets = false;
            int count = 0;
            foreach (char ch in s)
            {
                if (ch == '<')
                    inbrackets = true;
                else if (ch == '>')
                    inbrackets = false;
                else if (inbrackets)
                    ++count;
            }
            System.Console.WriteLine("count = " + count);
