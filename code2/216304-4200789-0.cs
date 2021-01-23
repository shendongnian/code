    class ActionEnumerator : IAction {
        readonly IEnumerator<IAction> enumerator;
        public ActionEnumerator(IEnumerator<IAction> enumerator) {
            this.enumerator = enumerator;
        }
        public void Execute() {
            //If the enumerator gives us another action,
            //hook up its Completed event to continue the
            //the chain, then execute it.
            if (enumerator.MoveNext()) {
                enumerator.Current.Completed += delegate { Execute(); };
                enumerator.Current.Execute();
            } else     //If the enumerator didn't give us another action, we're finished.
                OnCompleted();
        }
    }
    IEnumerator<IAction> SomeMethod() { 
        ...
        yield return new SomeAction();
        //This will only run after SomeAction finishes
        ...
        yield return new OtherAction();
        ...
    }
