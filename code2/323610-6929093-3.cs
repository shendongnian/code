    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    interface IWord
    {
        bool IsTypeOf(IWord word);
        string Text { get; set; }
        IWord MakeFrom(IWord word);
    }
    
    // the base type
    class UntypedWord : IWord
    {
        public virtual string Text { get; set; }
        public virtual bool IsTypeOf(IWord word)
        {
            throw new NotImplementedException();
        }
        public virtual IWord MakeFrom(IWord word)
        {
            throw new NotImplementedException();
        }
    }
    
    // one specific subtype
    class ColorWord : UntypedWord
    {
        public Color Color { get; private set; }
        public override bool IsTypeOf(IWord word)
        {
            return word.Text == "red" || word.Text == "green" || word.Text == "blue";
        }
        public override IWord MakeFrom(IWord word)
        {
            var newMe = new ColorWord();
            newMe.Text = word.Text;
            if (word.Text == "red") newMe.Color = Color.Red;
            else if (word.Text == "blue") newMe.Color = Color.Blue;
            else if (word.Text == "yellow") newMe.Color = Color.Yellow;
            return newMe;            
        }
    }
    // another specific type
    class NumberWord : IWord // note: not an UntypedWord (see comments below)
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public bool IsTypeOf(IWord word)
        {
            return word.Text == "one" || word.Text == "two" || word.Text == "three";
        }
        public IWord MakeFrom(IWord word)
        {
            var newMe = new NumberWord();
            newMe.Text = word.Text;
            if (word.Text == "one") newMe.Number = 1;
            else if (word.Text == "two") newMe.Number = 2;
            else if (word.Text == "three") newMe.Number = 3;
            return newMe;
        }
    }
    class WordList
    {
        Collection<Type> WordTypes = new Collection<Type>();
        Collection<IWord> UntypedWords = new Collection<IWord>();
        Dictionary<Type, Collection<IWord>> StronglyTypedWords = new Dictionary<Type, Collection<IWord>>();
        public void AddWordType<T>() where T : IWord
        {
            WordTypes.Add(typeof(T));
            if (!StronglyTypedWords.ContainsKey(typeof(T)))
                StronglyTypedWords[typeof(T)] = new Collection<IWord>();
        }
        public void Add(IWord word)
        {
            bool foundType = false;
            foreach (Type type in WordTypes)
            {
                // in practice you'd cache these factories for efficiency
                IWord instance = Activator.CreateInstance(type) as IWord;
                if (instance.IsTypeOf(word))
                {
                    if (!StronglyTypedWords.ContainsKey(type))
                        StronglyTypedWords[type] = new Collection<IWord>();
                    StronglyTypedWords[type].Add(instance.MakeFrom(word));
                    foundType = true;
                }
            }
            if (!foundType)
                UntypedWords.Add(word);
        }
        public int HowManyWordsOfType<T>()
        {
            if (StronglyTypedWords.ContainsKey(typeof(T)))
                return StronglyTypedWords[typeof(T)].Count;
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = new WordList();
            sentence.AddWordType<ColorWord>();
            sentence.AddWordType<NumberWord>();
            sentence.Add(new UntypedWord { Text = "two" });
            sentence.Add(new UntypedWord { Text = "green" });
            sentence.Add(new UntypedWord { Text = "frogs" });
            sentence.Add(new UntypedWord { Text = "and" });
            sentence.Add(new UntypedWord { Text = "one" });
            sentence.Add(new UntypedWord { Text = "red" });
            sentence.Add(new UntypedWord { Text = "rose" });
            Console.WriteLine("color words: " + sentence.HowManyWordsOfType<ColorWord>());
            Console.WriteLine("number words: " + sentence.HowManyWordsOfType<NumberWord>());
        }
    }    
