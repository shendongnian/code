    public class Ref
    {
        public static Ref<T> Create<T>(T value) => new Ref<T>(value);
    }
    public class Ref<T> : Ref
    {
        public Ref(T value) { Value = value; }
        public T Value { get; set; }
        public override string ToString() => Value?.ToString() ?? "";
        public static implicit operator T(Ref<T> r) => r.Value;
    }
    public static class RefExtensions
    {
        public static CancellationToken ToCancellationToken(this Ref<bool> cancelled)
        {
            var cts = new CancellationTokenSource();
            Task.Run(async () =>
            {
                while (!cancelled) await Task.Delay(100);
                cts.Cancel();
            });
            return cts.Token;
        }
    }
    public async Task Method(Ref<bool> isCancelled)
    {
        var cancellationToken = isCancelled.ToCancellationToken();
        while(!isCancelled)
        {
            ...
            DoThis();
            await DoTheNewThingAsync(cancellationToken);
            DoThat();
            ...
        }
    }
    
    public class Tests
    {
        [Fact]
        public async Task Fact()
        {
            var cancelled = Ref.Create(false);
    
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
