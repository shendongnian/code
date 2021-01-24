        private void button1_Click(object sender, EventArgs e)
        {
            string LangID = "DE";
            Dictionary<string, string> GermanDictionary = myDictionaries[LangID];
            string PhraseID = "str2";
            string GermanPhrase = GermanDictionary[PhraseID];
        }
