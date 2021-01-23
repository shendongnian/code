      static void Main(string[] args)
            {
                var input = "HellOWORLd";
                var i = 0;
                var x = 4;
                var len = input.Length;
                var output = new List<string>();
                while (x <= len)
                {
                    output.Add(SubStr(input, i, x));
                    i = x;
                    x += 2;
    
                }
                var ret = output.ToArray(); //["Hell","OW", "OR", "Ld"]
        
                Console.ReadLine();
    
                        
            }
         
    static string SubStr(string str, int start, int end)
                {
                    var len = str.Length;
                    if (start >= 0 && end <= len)
                    {
                        var ret = new StringBuilder();
                        for (int i = 0; i < len; i++)
                        {
                            if (i == start)
                            {
                                do
                                {
                                    ret.Append(str[i]);
                                    i++;
                                } while (i != end);
                            }
                        }
                        return ret.ToString();
                    }
                    return null;
                }
