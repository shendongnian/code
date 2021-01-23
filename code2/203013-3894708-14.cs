        IEnumerator<Car> enumerator = null;
        try
        {
            enumerator = query.GetEnumerator();
            Car aCar;
            while (enumerator.MoveNext())
            {
                aCar = enumerator.Current;
                Console.WriteLine(aCar.Name);
            }
        }
        finally
        {
            if (enumerator != null)
                ((IDisposable)enumerator).Dispose();
        }
