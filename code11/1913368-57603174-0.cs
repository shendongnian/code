            var aHash = A.ToHashSet();
            var bHash = B.ToHashSet();
            var result1 = new List<int>(A.Count);
            var result2 = new List<int>(B.Count);
            int value;
            foreach (int num in A)
            {
                if (bHash.TryGetValue(num, out value))
                    result1.Add(value);
            }
            foreach (int num in B)
            {
                if (aHash.TryGetValue(num, out value))
                    result2.Add(value);
            }
