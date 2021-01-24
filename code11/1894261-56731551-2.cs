    public class Bar
    {
        private readonly Random _random = new Random();
        private readonly IDictionary<int, Action> _actions = new Dictionary<int, Action>();
    
        public void OnClick()
            => _actions[_random.Next(_actions.Count)]?.Invoke();
    
        public void Register(Action action)
            => _actions[_actions.Count] = action;
    }
