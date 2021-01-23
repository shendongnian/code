    class UIHelper {
        public void AddRadioButtons(...);
    }
    interface ICriteria {
        void WorkOnUserInterface(UIHelper helper);
    }
    interface IChoices : ICriteria {
    }
    interface ITextCriteria : ICriteria {
    }
    class MultipleChoice : IChoices {
        public void WorkOnUserInterface(UIHelper helper) {
            helper.AddRadioButtons(...);
        }
    }
    class SimpleInput : ITextCriteria {
        public void WorkOnUserInterface(UIHelper helper) {
            // do nothing
        }
    }
