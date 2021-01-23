        public abstract class ManagerBase
        {
            public ManagerBase() { }
            public abstract void Initialize(int managerID, bool withUsers);
        }
        public class ManagerSomething1 : ManagerBase
        {
            public ManagerSomething1() 
            { }
            public override void Initialize(int managerID, bool withUsers)
            {
            }
        }
        public class ManagerSomething2 : ManagerBase
        {
            public ManagerSomething2()
            {
            }
            public override void Initialize(int managerID, bool withUsers)
            {
                throw new NotImplementedException();
            }
        }
        public static class SessionSharedHelper<T> where T : ManagerBase, new()
        {
            public static void InitializeSession(int managerID, bool withUsers)
            {
                T manager = new T();
                manager.Initialize(managerID, withUsers);
            }
        }
