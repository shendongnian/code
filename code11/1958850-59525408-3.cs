    public class PipelineBuilder<TContext> {
        private readonly Stack<Func<PipelineStep<TContext>, PipelineStep<TContext>>> steps =
            new Stack<Func<PipelineStep<TContext>, PipelineStep<TContext>>>();
        public PipelineBuilder<TContext> AddStep(Func<PipelineStep<TContext>, PipelineStep<TContext>> step) {
            steps.Push(step);
            return this;
        }
        public PipelineStep<TContext> Build() {
            var next = new PipelineStep<TContext>(context => Task.CompletedTask);
            while (steps.Any()) {
                var step = steps.Pop();
                next = step(next);
            }
            return next;
        }
    }
