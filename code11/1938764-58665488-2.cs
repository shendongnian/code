    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;
    
    public class BoolCancellation
    {
        private readonly bool? cancelled;
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
    
        public BoolCancellation(ref bool? cancelled)
        {
            this.cancelled = cancelled;
    
            Task.Run(async () =>
            {
                while (this.cancelled == true) await Task.Delay(100);
                cts.Cancel();
            });
        }
    
        public CancellationToken Token => cts.Token;
    }
    
    public class Tests
    {
        private Task Method(ref bool? isCancelled)
        {
            var cancellation = new BoolCancellation(ref isCancelled);
            return MethodImpl(cancellation.Token);
        }
    
        private async Task MethodImpl(CancellationToken cancellationToken) =>
            await DoTheNewThingAsync(cancellationToken);
    
        private async Task DoTheNewThingAsync(CancellationToken cancellationToken)
        {
            // Your stuff here.
            try
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
        }
    
        [Fact]
        public async Task Fact()
        {
            bool? cancelled = false;
    
            Task.Run(async () =>
            {
                await Task.Delay(100);
                cancelled = true;
            });
            
            var task = Method(ref cancelled);
    
            await Task.Delay(1000);
    
            await task;
    
            task.Status.Should().Be(TaskStatus.RanToCompletion);
        }
    }
