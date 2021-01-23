    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.Reflection;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                AggregateCatalog catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(IMessage).Assembly));
                CompositionContainer container = new CompositionContainer(catalog);
    
                Type t = typeof(IMessage);
                var m = container.GetExportedValue(t);
            }
        }
    
        public static class CompositionContainerExtension
        {
            public static object GetExportedValue(this ExportProvider container, Type type)
            {
                // get a reference to the GetExportedValue<T> method
                MethodInfo methodInfo = container.GetType().GetMethods()
                                          .Where(d => d.Name == "GetExportedValue"
                                                      && d.GetParameters().Length == 0).First();
    
                // create an array of the generic types that the GetExportedValue<T> method expects
                Type[] genericTypeArray = new Type[] { type };
    
                // add the generic types to the method
                methodInfo = methodInfo.MakeGenericMethod(genericTypeArray);
    
                // invoke GetExportedValue<type>()
                return methodInfo.Invoke(container, null);
            }
        }
    
        public interface IMessage
        {
            string Message { get; }
        }
    
        [Export(typeof(IMessage))]
        public class MyMessage : IMessage
        {
            public string Message
            {
                get { return "test"; }
            }
        }
    }
