    public class Ref
    {
        public static Ref<T> Create<T>(T value) => new Ref<T>(value);
    }
    public class Ref<T> : Ref
    {
        private T value;
        public Ref(T value) => Value = value;
        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChanged?.Invoke(value);
            }
        }
        public override string ToString() => Value?.ToString() ?? "";
        public static implicit operator T(Ref<T> r) => r.Value;
        public event Action<T> OnChanged;
    }
    public static class RefExtensions
    {
        public static CancellationToken ToCancellationToken(this Ref<bool> cancelled)
        {
            var cts = new CancellationTokenSource();
            cancelled.OnChanged += value => { if (value) cts.Cancel(); };
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
