    public interface IHashAlgorithm
    {
        int CalculateHash(int seed, params int[] keys);
        int CalculateNoise(int seed, params int[] keys);
        int Maximum { get; }
        int Minimum { get; }
    }
    public static class StatelessHashAlgorithms
    {
        private static readonly IHashAlgorithm MurmurHash2Instance =
            new HashAlgorithm(MurmurHash2Hash, 0, int.MaxValue);
    
        private static readonly IHashAlgorithm ReSharperInstance =
            new HashAlgorithm(ReSharperHash, int.MinValue, int.MaxValue);
    
        public static IHashAlgorithm MurmurHash2
        {
            get { return MurmurHash2Instance; }
        }
    
        public static IHashAlgorithm ReSharper
        {
            get { return ReSharperInstance; }
        }
    
        private static int MurmurHash2Hash(int seed, params int[] keys)
        {
            //...
        }
    
        private static int ReSharperHash(int seed, params int[] keys)
        {
            //...
        }
    }
    public class SomeCustomHashing : IHashAlgorithm
    {
       public SomeCustomHashing(parameters)
       {
          //parameters define how hashing behaves
       }
    
       // ... implement IHashAlgorithm here
    }
