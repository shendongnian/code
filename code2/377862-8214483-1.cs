    using System;
    namespace DZoneArticles.FactoryDesignPattern
    {
        public abstract class EmployeeFactory
        {
             public abstract Employee Create();
        }
        public class DBAFactory : EmployeeFactory
        {
             public override Employee Create() { return new DBA(); }
        }
        public class ManagerFactory : EmployeeFactory
        {
             public override Employee Create() { return new Manager(); }
        }
    }
