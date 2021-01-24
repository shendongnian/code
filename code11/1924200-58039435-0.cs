    using System;
    using System.Threading;
    using System.Threading.Tasks;
    public interface IFooAsync<TReturn> where TReturn : new()
    {
        Task<List<TReturn>> FooAsync<TProgress>(IProgress<TProgress> progress, 
                                                CancellationToken cancellationToken);
    }
