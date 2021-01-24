    class Program
    {
        static void Main(string[] args)
        {
            int[] change = Currency.MakeChange(41.37m);
            decimal sum = 0m;
            for (int i = 0; i < change.Length; i++)
            {
                var amount = change[i]*Currency.Denominations[i];
                sum += amount; 
                Debug.WriteLine($"{change[i]}×{Currency.Denominations[i]}");
            }
            Debug.WriteLine($"sum={sum}");
            // output:
            // 0×500
            // 0×200
            // 0×100
            // 0×50
            // 2×20
            // 0×10
            // 0×5
            // 0×2
            // 1×1
            // 0×0.5
            // 1×0.2
            // 1×0.1
            // 1×0.05
            // 2×0.01
            // sum=41.37
        }
    }
    public class Currency
    {
        public static readonly decimal[] Denominations =
            new decimal[] { 500m, 200m, 100m, 50m, 20m, 10m, 5m, 2m, 1m, 0.5m, 0.2m, 0.1m, 0.05m, 0.01m };
        public static int[] MakeChange(decimal value)
        {
            int[] change = new int[Denominations.Length];
            decimal remain = value;
            for (int i = 0; i < Denominations.Length; i++)
            {
                // get the next note (amount in currency).
                // must move from highest to smallest value.
                decimal note = Denominations[i];
                // can you divide the remainder with the note
                int qty = (int)(decimal.Floor(remain/note));
                change[i] = qty;
                // calculate remaining amount
                remain -= qty*note;
            }
            return change;
        }
    }
