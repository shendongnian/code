    public static IEnumerable<Note> ApplyCascades(this IEnumerable<Note> notes)
        {
            var uniques = new HashSet<Note>();
            Note rightToYield = null;
            foreach (var n in notes)
            {
                bool leftYielded = false;
                if (n.Cascade == Cascade.All) yield return n;
                if (n.Cascade == Cascade.Left && !leftYielded)
                {
                    yield return n;
                    leftYielded = true;
                }
                if (n.Cascade == Cascade.Right)
                {
                    rightToYield = n;
                }
                if (n.Cascade == Cascade.Unique && !uniques.Contains(n))
                {
                    yield return n;
                    uniques.Add(n);
                } 
            }
            if (rightToYield != null) yield return rightToYield;
        } 
    }
