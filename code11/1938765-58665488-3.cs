    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;
    
    public class Ref<T>
    {
        private Ref(T value) { Value = value; }
        public T Value { get; set; }
        public override string ToString() => Value?.ToString() ?? "";
        public static implicit operator T(Ref<T> r) { return r.Value; }
        public static Ref<T> Create(T value) { return new Ref<T>(value); }
    }
    
    public class Tests
    {
        private async Task Method(Ref<bool> isCancelled)
        {
            var cts = new CancellationTokenSource();
            Task.Run(async () =>
            {
                while (!isCancelled) await Task.Delay(100);
                cts.Cancel();
            });
            
            DoThis();
            await DoTheNewThingAsync(cts.Token);
            DoThat();
        }
    
        private void DoThis()
        {
        }
    
        private async Task DoTheNewThingAsync(CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
        }
    
        private void DoThat()
        {
        }
    
        [Fact]
        public async Task Fact()
        {
            var cancelled = Ref<bool>.Create(false);
    
            Task.Run(async () =>
            {
                await Task.Delay(500);
                cancelled.Value = true;
            });
            
            var task = Method(cancelled);
            await Task.Delay(1000);
    
            task.Status.Should().Be(TaskStatus.RanToCompletion);
        }
    }
