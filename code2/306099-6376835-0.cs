    public partial class AsyncWaitDialog : Form, IAsyncDialog
    {
        ...
        Func<TResult> _workWithReturn; //TRESULT IS NOT IN SCOPE
        ...
    
        public TResult ShowDialogWhile<TResult>(Func<TResult> work)
        {
            //TResult **IS** in scope here
            _workWithReturn = work;
            _worker.RunWorkerAsync();
            this.CenterForm();
            this.ShowDialog();
    
            return (TResult)Result;
        }
    // possible solution, move the generic definition of TResult to the class definition
    public partial class AsyncWaitDialog<TResult> : Form, IAsyncDialog { ... }
