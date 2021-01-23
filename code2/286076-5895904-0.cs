    public class MyWord : IComparable<MyWord>
    {
        public MyWord(string word)
        {
            this.Word = word;
            this.Frequency = 0;
        }
        public MyWord(string word, int frequency)
        {
            this.Word = word;
            this.Frequency = frequency;
        }
        public string Word { get; private set;}        
        public int Frequency { get; private set;}
        public void IncrementFrequency()
        {
            this.Frequency++;
        }
        public void DecrementFrequency()
        {
            this.Frequency--;
        }
        public int CompareTo(MyWord secondWord)
        {
            return this.Frequency.CompareTo(secondWord.Frequency);
        }
    }
