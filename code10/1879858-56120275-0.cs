    namespace Test
    {
        public interface IArbitraryQualifier
        {
            int Qualification { get; }
        }
        public class ArbitraryQualifier : IArbitraryQualifier
        {
            public const int MIN_QUALITY = 1;
            public int Qualification { get; }
        }
        public class Person
        {
            public IArbitraryQualifier ArbitraryQualifier { get; }
            public bool AmIARealBoy => 
                ArbitraryQualifier.Qualification >= Test.ArbitraryQualifier.MIN_QUALITY;
        }
    }
