        static List<int> MixedSum(int[] v, int[] w)
        {
            var rx = new List<int>();
            for (int c = 0; c < v.Length; c++)
            {
                for (int d = 0; d < w.Length; d++)
                {
                    rx.Add(v[c] + w[d]);
                }
            }
    
            return rx;
        }
    
        // output
        foreach(var num in MixedSum([], [])) {
            Console.WriteLine(num);
        }
