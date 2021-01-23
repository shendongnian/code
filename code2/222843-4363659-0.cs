            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            txtOriginal.Text="this string is to test. a quick brown fox jump over the lazy dog. dog bytes on fox's leg ang gosht";
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            string stringToModify = getString();
            string[] words=splitWords(stringToModify);
            string urls = txtUrls.Text;
            string[] urlString = urls.Split(',');
            for(int i=0;i<urlString.Length;i++)
            {
                string url = urlString[i];
                Random index = new Random();
                int position = index.Next(words.Length);
                if (checkIfUsed(position) == false)
                {
                    usedPositions.Add(position);
                    string tempWord = words[position];
                    tempWord = "<a href='" + url + "'>" + tempWord + "</a>";
                    words[position] = tempWord;
                }
                else
                    i--;
            }
            /*if(txtUrls!=null)
            {
               
                for (int i = 0; i < urlString.Length; i++)
                {
                    stringToModify.Replace(words[position], "<a href=" + urlString[i] + ">" + words[position] + "</a>");
                }
            }
             * */
        }
 
        //function to check if random place already used
        private bool checkIfUsed(int radomNum)
        {
            if (usedPositions.Contains(radomNum))
                return true;
            else
                return false;
        }
        private string getString()
        {
            string myString = txtOriginal.Text;
            string mySubString = myString.Substring(0, 2 * (myString.Length / 3));
            return mySubString;
        }
       //so i can get word to wrap html around it
        private string[] splitWords(string s)
        {
             string[] words= Regex.Split(s, @"/W+");
             return words;
        }
  
