    static void Main(string[] args)
            {
                string msg = "This is a small message !This is a small message !This is a small message !";
                string substring = "This is a small message !";
    
                string[] split = msg.Split(new string[] { substring }, StringSplitOptions.None);
    
                Console.WriteLine(split.Length - 1);
            }
