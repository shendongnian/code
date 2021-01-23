    using System;
    using System.Threading;
    /// <summary>
    /// DisposableBase class. Represents an implementation of the IDisposable interface.
    /// </summary>
    public abstract class DisposableBase : IDisposable
    {
        /// <summary>
        /// A value which indicates the disposable state. 0 indicates undisposed, 1 indicates disposing
        /// or disposed.
        /// </summary>
        private int disposableState;
        /// <summary>
        /// Finalizes an instance of the DisposableBase class.
        /// </summary>
        ~DisposableBase()
        {
            // The destructor has been called as a result of finalization, indicating that the object
            // was not disposed of using the Dispose() method. In this case, call the DisposeResources
            // method with the disposeManagedResources flag set to false, indicating that derived classes
            // may only release unmanaged resources.
            this.DisposeResources(false);
        }
        /// <summary>
        /// Gets a value indicating whether the object is undisposed.
        /// </summary>
        public bool IsUndisposed
        {
            get
            {
                return Thread.VolatileRead(ref this.disposableState) == 0;
            }
        }
        #region IDisposable Members
        /// <summary>
        /// Performs application-defined tasks associated with disposing of resources.
        /// </summary>
        public void Dispose()
        {
            // Attempt to move the disposable state from 0 to 1. If successful, we can be assured that
            // this thread is the first thread to do so, and can safely dispose of the object.
            if (Interlocked.CompareExchange(ref this.disposableState, 1, 0) == 0)
            {
                // Call the DisposeResources method with the disposeManagedResources flag set to true, indicating
                // that derived classes may release unmanaged resources and dispose of managed resources.
                this.DisposeResources(true);
                // Suppress finalization of this object (remove it from the finalization queue and
                // prevent the destructor from being called).
                GC.SuppressFinalize(this);
            }
        }
        #endregion IDisposable Members
        /// <summary>
        /// Dispose resources. Override this method in derived classes. Unmanaged resources should always be released
        /// when this method is called. Managed resources may only be disposed of if disposeManagedResources is true.
        /// </summary>
        /// <param name="disposeManagedResources">A value which indicates whether managed resources may be disposed of.</param>
        protected abstract void DisposeResources(bool disposeManagedResources);
    }
