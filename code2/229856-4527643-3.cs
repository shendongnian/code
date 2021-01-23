    interface ICriteria {
        void PerformProcessingOn(ICriteriaView view);
    }
    interface IChoices : ICriteria {
    }
    interface ITextCriteria : ICriteria {
    }
