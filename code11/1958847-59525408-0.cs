    public class ProcessBuilder<TContext> {
        private readonly Stack<Func<ProcessingDelegate<TContext>, ProcessingDelegate<TContext>>> components =
            new Stack<Func<ProcessingDelegate<TContext>, ProcessingDelegate<TContext>>>();
        public ProcessBuilder<TContext> Add(Func<ProcessingDelegate<TContext>, ProcessingDelegate<TContext>> step) {
            components.Push(step);
            return this;
        }
        public ProcessingDelegate<TContext> Build() {
            var next = new ProcessingDelegate<TContext>(context => Task.CompletedTask);
            while (components.Any()) {
                var component = components.Pop();
                next = component(next);
            }
            return next;
        }
    }
