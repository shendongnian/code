        public void optionSameSignature(Action<string> log = null, Func<string> read = null)
        {
            log = log ?? Console.WriteLine;
            read = read ?? Console.ReadLine;
            string str = "The Haunting of Hill House!";
            log("String: " + str);
            string occurString = "o";
            string replaceString = "MDDS";
            var array = str.Split(new[] { occurString }, StringSplitOptions.None);
            var count = array.Length - 1;
            string result = string.Join(replaceString, array);
            log("String after replacing a character: " + result);
            log("Number of replaces made: " + count);
            read();
        }
        public void Test()
        {
            List<string> lines = new List<string>();
            optionSameSignature(lines.Add, () => "");
        }
