    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    
    namespace MEFCastleBridge
    {
        public class CastleExportProvider : ExportProvider
        {
            WindsorContainer _container;
            private readonly Dictionary<ExportDefinition, List<Export>> _exports =
                new Dictionary<ExportDefinition, List<Export>>();
            private readonly object _sync = new object();
    
            public CastleExportProvider(WindsorContainer container)
            {
                _container = container;
                var handlers = _container.Kernel.GetAssignableHandlers(typeof(object));
                foreach (var handler in handlers)
                {
                    RegisterCastleComponent(handler);
                }
                _container.Kernel.ComponentRegistered += ComponentRegistered;
            }
    
            protected override IEnumerable<Export> GetExportsCore(
                ImportDefinition definition, AtomicComposition atomicComposition)
            {
                var contractDefinition = definition as ContractBasedImportDefinition;
                var retVal = Enumerable.Empty<Export>();
                if (contractDefinition != null)
                {
                    string contractName = contractDefinition.ContractName;
                    if (!string.IsNullOrEmpty(contractName))
                    {
                        var exports =
                           from e in _exports
                           where string.Compare(e.Key.ContractName, contractName, StringComparison.OrdinalIgnoreCase) == 0
                           select e.Value;
    
                        if (exports.Count() > 0)
                        {
                            retVal = exports.First();
                        }
                    }
                }
    
                return retVal;
            }
    
            void RegisterCastleComponent(IHandler handler)
            {
                var type = handler.Service;
                var contractName = type.ToString();
                lock (_sync)
                {
                    var found = from e in _exports
                                where string.Compare(e.Key.ContractName, 
                                    contractName, StringComparison.OrdinalIgnoreCase) == 0
                                select e;
    
                    if (found.Count() == 0)
                    {
                        var metadata = new Dictionary<string, object>();
                        var definition = new ExportDefinition(contractName, metadata);
                        _exports.Add(definition, new List<Export>());
                    }
    
                    var wrapper = new Export(contractName, () => _container.Resolve(type));
                    found.First().Value.Add(wrapper);
                }
            }
    
            void ComponentRegistered(string key, IHandler handler)
            {
                RegisterCastleComponent(handler);
            }
        }
    
        public interface IMyComponent
        {
            string TheString { get; }
        }
    
        public class RegisteredComponent : IMyComponent
        {
            public string TheString { get { return "RegisteredComponent"; } }
        }
    
        [Export(typeof(IMyComponent))]
        public class ExportedComponent : IMyComponent
        {
            public string TheString { get { return "ExportedComponent"; } }
        }
    
        public class ExportExample
        {
            // Will contain an instance of RegisteredComponent and ExportedComponent
            [ImportMany]
            public List<IMyComponent> Components { get; set; }
            
            public ExportExample()
            {
                // Create a Windsor container and add a type.
                var container = new WindsorContainer();
                container.Register(Component.For<IMyComponent>().ImplementedBy<MyComponent>().LifeStyle.Singleton);
                // Add the Export Provider, in addition to the DeploymentCatalog
                var compContainer = new CompositionContainer(new DeploymentCatalog(), new CastleExportProvider(container));
                // Should only be called once, before any attempt to SatisfyImports.
                CompositionHost.Initialize(compContainer);
                CompositionInitializer.SatisfyImports(this);
    
                Test = string.Join(", ", Components.Select(c => c.DoSomething));
            }
    
            public string Test { get; set; }
        }
    }
