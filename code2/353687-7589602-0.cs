    [Test]
    public void TestDictionary()
    {
        var dictionary = new Dictionary();
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine(dictionary.GetNext());
        }
    }
    public class Dictionary
    {
        //private Random m_RandomGenerator = new Random(12);
        private Random m_RandomGenerator = new Random();
        public int GetNext()
        {
            return m_RandomGenerator.Next(100);
        }
    }
