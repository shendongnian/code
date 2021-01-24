    public class OrderDB
    {
         private Random rnd = new Random();
         .... other class code....
        private string loadOrderNr()
        {
            // Do you really use the Db variable here? Otherwise you can remove it
            using (Db db = new Db())
            {
                // Random rnd = new Random();
                long part1 = rnd.Next(100000, 999999);
                long part2 = rnd.Next(1000, 9999);
                string OrderNr = "CA-" + part1 + "-" + part2;
                return OrderNr;
            } 
        }
    }
