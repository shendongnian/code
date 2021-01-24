    public class RecursiveTask<T>
    {
        private T _result;
        private Func<RecursiveTask<T>> _function;
        public T Result
        {
            get
            {
                var current = this;
                var last = current;
                do
                {
                    last = current;
                    current = current._function?.Invoke();
                } while (current != null);
                return last._result;
            }
        }
        private RecursiveTask(Func<RecursiveTask<T>> function)
        {
            _function = function;
        }
        private RecursiveTask(T result)
        {
            _result = result;
        }
        public static implicit operator RecursiveTask<T>(T result)
        {
            return new RecursiveTask<T>(result);
        }
        public static RecursiveTask<T> FromFunc(Func<RecursiveTask<T>> func) => new RecursiveTask<T>(func);
    }
