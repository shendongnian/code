    class Employee : IBaseClass
    {
        private Dictionary<int, int> vacationWeeksTable;
        public virtual void RegisterSharedHandlers(int? group, Action<IKey, int?, EventHandlerTypes, Action<object, SharedEventArgs>> register)
        {
            group = 0; // disable different groups
            register(new Key<Employee, int>(0), group, EventHandlerTypes.SetInitialData, SetVacationWeeksTable);
        }
        public virtual void RegisterSharedData(Action<IKey, object> regData)
        {
            // remove this from factory and interface, you probably dont need it
            // I have been using it as a FlyWeight data store for classes.            
        }
        private void SetVacationWeeksTable(object sender, SharedEventArgs e)
        {
            vacationWeeksTable = e.GetData<Dictionary<int, int>>();
        }
    }
