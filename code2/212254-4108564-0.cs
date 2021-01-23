    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate.Cfg;
    using NHibernate;
    
    namespace ExecutableHQL
    {
      class Program
      {
        static void Main(string[] args)
        {
          log4net.Config.XmlConfigurator.Configure();
          var nhConfig = new Configuration().Configure();
          var sessionFactory = nhConfig.BuildSessionFactory();
    
          using (var session = sessionFactory.OpenSession())
          {
            using (var tx = session.BeginTransaction())
            {
              int count = (int) session.CreateQuery("select count(*) from Trip").UniqueResult();
    
              tx.Commit();
            }
          }
        }
      }
    }
