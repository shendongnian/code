    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;
    
    public class BoolCancellation
    {
        private readonly bool cancelled;
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
    
        public BoolCancellation(ref bool cancelled)
        {
            cancelled = cancelled;
    
            Task.Run(async () =>
            {
                while (!this.cancelled) await Task.Delay(100);
                cts.Cancel();
            });
        }
    
        public CancellationToken Token => cts.Token;
    }
    
    public class Tests
    {
        private Task Method(ref bool isCancelled)
        {
            var cancellation = new BoolCancellation(ref isCancelled);
            return MethodImpl(cancellation.Token);
        }
    
        private async Task MethodImpl(CancellationToken cancellationToken) =>
            await DoTheNewThingAsync(cancellationToken);
    
        private async Task DoTheNewThingAsync(CancellationToken cancellationToken)
        {
            // Your stuff here.
            await Task.Yield();
        }
    
        [Fact]
        public async Task Fact()
        {
            var cancelled = false;
            var task = Method(ref cancelled);
            await Task.Delay(1000);
            cancelled = true;
    
            await task;
    
            task.Status.Should().Be(TaskStatus.RanToCompletion);
        }
    }
