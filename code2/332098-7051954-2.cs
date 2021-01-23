    namespace StackOverflow7051864
    {
        using System;
    
        public interface ITransaction : IDisposable {}
    
        public interface ITryToConfuseDispose
        {
            void Dispose();
        }
    
        public class Transaction : ITransaction, ITryToConfuseDispose
        {
            void IDisposable.Dispose()
            {
                Console.WriteLine("Happy");
            }
    
            void ITryToConfuseDispose.Dispose()
            {
                Console.WriteLine("Confused");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                EndTransaction(new Transaction());
            }
    
            public static void EndTransaction(ITransaction transaction)
            {
                (transaction as IDisposable).Dispose();
    
                transaction.Dispose();            
            }
        }
    }
