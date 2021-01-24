    public interface IDependency {
        Task DoSomething();
    }
    public class Worker {
        private readonly IDependency dependency;
        public Worker(IDependency dependency) {
            this.dependency = dependency;
        }
        public async Task Run(CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested) {
                try {
                    // do something like claim a resource
                    await dependency.DoSomething();
                } catch (Exception e) {
                    // catch exceptions and print to the log
                } finally {
                    // release the resource
                }
            }
        }
    }
