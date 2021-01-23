    interface ITask {
        PrioirtyType Prioirty { get; }
        bool Complete { get; }
        void PerformOneUnitOfWork();
    }
