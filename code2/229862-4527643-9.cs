    class MultipleChoice : IChoices {
        public PerformProcessingOn(ICriteriaView view) {
            view.ProcessCriteria(this);
        }
    }
    class SimpleInput : ITextCriteria {
        public PerformProcessingOn(ICriteriaView view) {
            view.ProcessCriteria(this);
        }
    }
