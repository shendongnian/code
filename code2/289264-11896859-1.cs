        public static long LargestProduct(int[] arr)
        {
            if (arr.Length == 1)
                return arr[0];
            int lastNumber = 1;
            List<long> latestProducts = new List<long>();
            long maxProduct = Int64.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                var item = arr[i];
                var latest = lastNumber * item;
                var temp = new long[latestProducts.Count];
                latestProducts.CopyTo(temp);
                latestProducts.Clear();
                foreach (var p in temp)
                {
                    var product = p * item;
                    if (product > maxProduct)
                        maxProduct = product;
                    latestProducts.Add(product);
                }
                if (i != 0)
                {
                    if (latest > maxProduct)
                        maxProduct = latest;
                    latestProducts.Add(latest);
                }
                lastNumber = item;
            }
            return maxProduct;
        }
