    public class Check
    {
        public int Calculate(Book product)
        {
            var sum = product.Price + product.Price2;
            Console.WriteLine(sum);
            return sum;
        }
    }
