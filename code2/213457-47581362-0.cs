        /// <summary>
        /// Capitalize first letter of every sentence. 
        /// </summary>
        /// <param name="inputSting"></param>
        /// <returns></returns>
        public string CapitalizeSentences (string inputSting)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(inputSting))
            {
                string[] sentences = inputSting.Split('.');
                foreach (string sentence in sentences)
                {
                    result += string.Format ("{0}{1}.", sentence.First().ToString().ToUpper(), sentence.Substring(1)); 
                }
            }
            return result; 
        }
