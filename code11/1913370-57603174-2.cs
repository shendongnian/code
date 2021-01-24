            var aHash = list<A>.ToHashSet(x=>x.ID);
            var bHash = list<B>.ToHashSet(x=>x.ID);
            var result1 = new List<A>(A.Count);
            var result2 = new List<B>(B.Count);
            int value;
            foreach (A item in list<A>)
            {
                if (!bHash.TryGetValue(item.ID, out value))
                    result1.Add(A);
            }
            foreach (B item in list<B>)
            {
                if (!aHash.TryGetValue(item.ID, out value))
                    result2.Add(B);
            }
