    public static bool Remove<T>(this BlockingCollection<T> self, T itemToRemove)
        {
            lock (self)
            {
                T comparedItem;
                var itemsList = new List<T>();
                do
                {
                    var result = self.TryTake(out comparedItem);
                    if (!result)
                        return false;
                    if (!comparedItem.Equals(itemToRemove))
                    {
                        itemsList.Add(comparedItem);
                    }
                } while (!(comparedItem.Equals(itemToRemove)));
                Parallel.ForEach(itemsList, t => self.Add(t));
            }
            return true;
        }
