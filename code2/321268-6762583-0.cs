        using (IEnumerator<T> enumerator = collection.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                if (SatisfyResetCondition(enumerator.Current))                          
                    enumerator.Reset();
                Console.WriteLine(enumerator.Current);
            }
        }
