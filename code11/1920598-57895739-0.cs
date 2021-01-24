cs
using Autofac;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace InstanceRequest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ScopeAccessor>()
                .AsSelf()
                .As<IResolver>()
                .SingleInstance();
            builder.RegisterType<SingleInstance>()
                .SingleInstance();
            builder.RegisterType<IdAccessor>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Request>()
                .InstancePerLifetimeScope();
            using (var container = builder.Build())
            {
                await RunAsync(container);
            }
        }
        private static async Task RunAsync(IContainer container)
        {
            var accessor = container.Resolve<ScopeAccessor>();
            var tasks = Enumerable.Range(0, 100).Select(async id =>
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    accessor.CurrentScope = scope;
                    await scope.Resolve<Request>().RunAsync();
                }
            });
            await Task.WhenAll(tasks);
        }
    }
    class Request
    {
        private readonly IdAccessor _id;
        private readonly SingleInstance _s;
        public Request(IdAccessor id, SingleInstance s)
        {
            _id = id;
            _s = s;
        }
        public async Task RunAsync()
        {
            while (true)
            {
                var fromScoped = _id.Id;
                var fromSingleton = _s.Id;
                if (fromScoped != fromSingleton)
                {
                    throw new InvalidOperationException();
                }
                Console.WriteLine($"{fromScoped} == {fromSingleton}");
                await Task.Delay(100);
            }
        }
    }
    class SingleInstance
    {
        private readonly IResolver _resolver;
        public SingleInstance(IResolver resolver)
        {
            _resolver = resolver;
        }
        public int Id => _resolver.Resolve<IdAccessor>().Id;
    }
    interface IResolver
    {
        T Resolve<T>();
    }
    class ScopeAccessor : IResolver
    {
        private readonly AsyncLocal<ILifetimeScope> _scope = new AsyncLocal<ILifetimeScope>();
        public ILifetimeScope CurrentScope
        {
            get => _scope.Value;
            set => _scope.Value = value;
        }
        public T Resolve<T>() => CurrentScope.Resolve<T>();
    }
    class IdAccessor
    {
        private static int _id = 0;
        public IdAccessor()
        {
            Id = Interlocked.Increment(ref _id);
        }
        public int Id { get; }
    }
}
I will note, however, that using something like `AsyncLocal<T>` or `[ThreadStatic]` will incur a non-trivial cost as well and may be more than the GC pressure you think you are experiencing.
