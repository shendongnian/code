    public enum MethodType
    {
        Action,
        Function
    }
    public class Encapsulator<T>
    {
        private Action _action;
        private Func<T> _function;
        private MethodType _type;
        public Encapsulator(Action action)
        {
            this._action = action;
            this._type = MethodType.Action;
        }
        public Encapsulator(Func<T> func)
        {
            this._function = func;
            this._type = MethodType.Function;
        }
        public void Execute()
        {
            try
            {
                this._action();
            }
            catch (Exception ex)
            {
                //do something
                throw;
            }
        }
        public T ExecuteFunc()
        {
            try
            {
                object res = this._function();
                Nullable<bool> bres = res as Nullable<bool>;
                if (bres.HasValue)
                {
                    if (!bres.Value)
                        Console.WriteLine("NOT TRUE!");
                    //do something
                }
                return (T)res;
            }
            catch (Exception ex)
            {
                //do something
                throw;
            }
        }
    }
