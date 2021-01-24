    public class Word
    {
        public string word;
        private int typeIndex; // Checks for current letter
        private int wordIndex; // index of word used from WordGenerator
        WordDisplay display;
        public Word(WordDisplay _display)  // Displays the word as Hiragana / Katakana
        {
            wordIndex = WordGenerator.GetIndex(); // now it will only be called ONCE per instance
            word = _WordGenerator.wordList_Romaji[wordIndex];
            
            // you can get the equivalent? letters similarly...with something like:
            word = _WordGenerator.wordList_Hiragana[wordIndex];
            display = _display;
            display.SetWord(word);
        }
        // ... other existing code ...
    }
