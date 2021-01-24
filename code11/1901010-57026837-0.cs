    public class PagedModelBase<T> : MainModelBase
    {
        internal bool Delete(int id)
        internal List<T> ReloadPage()
        internal List<T> FirstPage()
        internal List<T> LastPage()
        internal List<T> NextPage()
        internal List<T> PreviousPage()
        internal List<T> CustomPage(int customPage)
        private List<T> LoadPage()
    }
    
    public class ContractModel : PagedModelBase<ContractTableRow> 
    {
        // contract specific implementation here
    }
    
    public class WorkerModel : PagedModelBase<WorkerTableRow>
    {
        // worker specific implementation here
    }
