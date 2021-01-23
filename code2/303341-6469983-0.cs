    class ManagerBaseFactory
    {
        private readonly IEnumerable<ManagerBase> _managers;
    
        public ManagerBaseFactory(IEnumerable<ManagerBase> managers)
        {
            _managers = managers;
        }
    
        public ManagerBase GetInstance(SomeEnum e)
        {
            Type t;
    
            switch (e)
            {
                case SomeEnum.A:
                    t = typeof(Manager1);
                    break;
                case SomeEnum.B:
                    t = typeof(Manager2);
                    break;
                case SomeEnum.C:
                    t = typeof(Manager3);
                    break;
                default:
                    return null;
            }
            return _managers.FirstOrDefault(m => m.GetType().Equals(t));
        }
    }
