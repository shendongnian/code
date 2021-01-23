    public class Word
    {
        public virtual int Id { get; set; }
        public virtual string Text { get; set; }
        public virtual IList<Word> Synonyms { get; set; }
        public virtual IList<Word> Antonyms { get; set; }
    }
