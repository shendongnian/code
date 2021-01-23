    using System;
    using System.Reflection;
    using FluentNHibernate;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using NHibernate;
    using NHibernate.Tool.hbm2ddl;
    
    public interface IEntity
    {
        int Id { get; set; }
    }
    
    public abstract class MyBaseClass : IEntity
    {
        public virtual int Id { get; set; }
    
        public class MyBaseClassMap : IAutoMappingOverride<MyBaseClass>
        {
            public void Override(AutoMapping<MyBaseClass> mapping)
            {
                mapping.DiscriminateSubClassesOnColumn("ChildClassType", "MyBaseClassMap");
            }
        }
    }
    
    public class MyFirstChildClass : MyBaseClass
    {
        public virtual string Child1 { get; set; }
    }
    
    public class MySecondChildClass : MyBaseClass
    {
        public virtual string Child2 { get; set; }
    }
    
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            string table = string.Format("{0}_HiLo", instance.EntityType.Name);
            instance.GeneratedBy.HiLo(table, "next_hi", "100");
        }
    }
    
    public class MyMappingConfig : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            if (type.GetInterface(typeof(IEntity).FullName) != null)
                return true;
    
            return false;
        }
    
        public override bool AbstractClassIsLayerSupertype(Type type)
        {
            if (type == typeof(IEntity))
                return true;
            return false;
        }
    
        public override bool IsId(Member member)
        {
            return member.Name == "Id";
        }
    
        public override bool IsDiscriminated(Type type)
        {
            if (type.IsAssignableFrom(typeof(MyBaseClass)) || type.IsSubclassOf(typeof(MyBaseClass)))
                return true;
    
            return false;
        }
    }
    
    
    public class Program
    {
        private static ISession InitializeNHibertnat(Assembly mapAssembly)
        {
            var automappingConfiguration = new MyMappingConfig();
    
            var fluentConfiguration =
                Fluently.Configure().Database(SQLiteConfiguration.Standard.InMemory());
    
            fluentConfiguration = fluentConfiguration
                .Mappings(m => m.AutoMappings
                                   .Add(AutoMap.Assembly(mapAssembly, automappingConfiguration)
                                            .Conventions.Add<PrimaryKeyConvention>()
                                            .UseOverridesFromAssembly(mapAssembly)))
                .Mappings(m => m.FluentMappings
                                   .AddFromAssembly(mapAssembly))
                .Mappings(m => m.HbmMappings
                                   .AddFromAssembly(mapAssembly))
                .ExposeConfiguration(cfg => cfg.SetProperty("generate_statistics", "true"))
                .ExposeConfiguration(cfg => cfg.SetProperty("show_sql", "true"))
                .ExposeConfiguration(cfg => cfg.SetProperty("adonet.batch_size", "1"));
    
    
            var configuration = fluentConfiguration.BuildConfiguration();
            var sessionFactory = configuration.BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            new SchemaExport(configuration).Execute(false, true, false, session.Connection, null);
    
            return session;
        }
    
        static void Main()
        {
            var mfcc = new MyFirstChildClass();
            mfcc.Id = 1;
            mfcc.Child1 = "Child One";
    
            var mscc = new MySecondChildClass();
            mscc.Id = 2;
            mscc.Child2 = "Child Two";
    
            var Session = InitializeNHibertnat(Assembly.GetExecutingAssembly());
            using (var tx = Session.BeginTransaction())
            {
                Session.Save(mfcc);
                Session.Save(mscc);
                tx.Commit();
            }
        }
    }
