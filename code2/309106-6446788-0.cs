    public class CustomCollection<T> extends ConcurrentIterable<T>
    {
        private T[] data;
        private int size;
        @Override
        protected void provideElements()
        {
            for (int i = 0; i < size; ++i)
            {
                provideElement(data[i]);
            }
        }
        // ...
    }
