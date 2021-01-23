        using (var iterator1 = sequence1.GetEnumerator())
        using (var iterator2 = sequence2.GetEnumerator())
        {
            while (iterator1.MoveNext() && iterator2.MoveNext())
            {
                var value1 = iterator1.Current;
                var value2 = iterator2.Current;
                // Use the values here
            }
        }
