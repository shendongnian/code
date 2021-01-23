           //Your range will come here
            IEnumerable<double> d=Enumerable.Range(2.67,100);
           // Your condition
           d.Where(d1 => d1 % 2.0 == 0).CumulativeSum();
    
     public static class Extension
    
        {
            public static IEnumerable<double> CumulativeSum(this IEnumerable<double> sequence)
            {
                double sum = 0;
                foreach (var item in sequence)
                {
                    sum += item;
                    yield return sum;
                }
            }
    
        }
