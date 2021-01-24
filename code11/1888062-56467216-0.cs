    public class MetodoList
    {
        private readonly List<Action> _metodos = new List<Action>();
        public void Add(Metodo metodo)
        {
            _metodos.Add(metodo.Invoke);
        }
        public void Add<T>(Metodo<T> metodo, T argument)
        {
            _metodos.Add(() => metodo.Invoke(argument));
        }
        public void Add<T, U>(Metodo<T, U> metodo, T thing, U uther)
        {
            _metodos.Add(() => metodo.Invoke(thing, uther));
        }
        // more of these.
        public void InvokeAll()
        {
            _metodos.ForEach(m => m.Invoke());
        }
    }
