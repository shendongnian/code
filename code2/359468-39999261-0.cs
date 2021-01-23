        /// <summary>
        /// Return hello = Item1 and world Item2
        /// </summary>
        /// <param name="input">string to split</param>
        /// <returns></returns>
        private static Tuple<bool, bool> helloworld(string input)
        {
            bool hello = false;
            bool world = false;
            foreach (var hw in input.Split(','))
            {
                switch (hw)
                {
                    case "Hi1":
                        hello= true;
                        break;
                    case "Hi2":
                        world= true;
                        break;
                }
            }
            return new Tuple<bool, bool>(hello, world);
        }`
