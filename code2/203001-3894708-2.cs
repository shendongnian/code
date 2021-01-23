            foreach(Car aCar in query)
            {
                 Console.WriteLine(aCar.Name);
            }
            IEnumerator<Car> enumerator = null;
            try
            {
                enumerator = query.GetEnumerator();
                Car aCar;
                while (enumerator.GetNext())
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
