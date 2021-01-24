    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;
    
    namespace Threading
    {
        /// <summary>
        ///     Defines an object that switches to a thread.
        /// </summary>
        [PublicAPI]
        public interface IThreadSwitcher : INotifyCompletion
        {
            bool IsCompleted { get; }
    
            IThreadSwitcher GetAwaiter();
    
            void GetResult();
        }
    }
