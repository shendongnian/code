    public class Deck
    {
        // Implementation omitted
    }
    public static class Extensions
    {
        private static Random rng = new Random();  
        // This extension method is now available to any class that implements 'IList'
        public static void Shuffle<T>(this IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) 
            {  
                n--;  
                int k = rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }
    }
