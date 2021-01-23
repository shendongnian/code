    public Form1()
    {
        controller = new EmployeeController( SynchronizationContext.Current );
        ...
    class EmployeeController
    {
        private SynchronizationContext _SynchronizationContext = null;
        public EmployeeController( SynchronizationContext sc )
        {
            _SynchronizationContext = sc;
            ...
