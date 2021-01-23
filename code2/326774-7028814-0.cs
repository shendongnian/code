    /// <summary>
    /// Allows progress to be monitored on a multi step operation
    /// </summary>
    interface ISteppedOperation
    {
        /// <summary>
        /// Move to the next item to be processed.
        /// </summary>
        /// <returns>False if no more items</returns>
        bool MoveNext();
    
        /// <summary>
        /// Processes the current item
        /// </summary>
        void ProcessCurrent();
        
        int StepCount { get; }
        int CurrentStep { get; }
    }
