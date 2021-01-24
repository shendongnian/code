        public char[] charArr; // Or private. 
        public int wordLength; // Just make sure it is inside the class.
        // ...
        public void generateLetters(string word) {
            charArr = word.ToCharArray();
            wordLength = charArr.Length;
        }
