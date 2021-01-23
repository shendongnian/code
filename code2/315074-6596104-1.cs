    ArrayList lines = GetLines("test.txt", "8394", true);
     string result;       
     foreach (string s in lines)
            {
                result = s;
                Console.WriteLine(result);
            }
