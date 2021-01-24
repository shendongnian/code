    public class DisposableList<T> : List<T>, IDisposable
    {
        public void Dispose()
        {
            foreach (T item in this)
            {
                try
                {
                    IDisposable disposableItem = item as IDisposable;
                    if (disposableItem != null)
                    {
                        disposableItem.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    ///Log and do something
                }
            }
            this.Clear();
            this.TrimExcess();
        }
    }
