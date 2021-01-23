    interface IAction { void Execute(Action callback); }
    public static void ExecAction(IEnumerator<IAction> enumerator) {
        if (enumerator.MoveNext())
            enumerator.Current.Execute(() => ExecAction(enumerator));
    }
    
    class WaitForLoad : IAction {
        void IAction.Execute(Action callback) {
           //Handle the LoadCompleted event and call callback
        }
    }
    
    IEnumerator<IAction> YourMethod() { 
        ...
        for (int i = 0; i < NumberOfPages; i++) {
            WebBrowser.Navigate("http://AWebSite/" + NumberOfPages.ToString());
            yield return new WaitForLoad();
        }
        ...
    }
