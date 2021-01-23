    using SimpleInjector.Advanced;
    using System.ComponentModel.Composition;
    public class ImportAttributePropertySelectionBehavior
        : IPropertySelectionBehavior
    {
        public bool SelectProperty(Type serviceType, PropertyInfo p)
        {
            return p.GetCustomAttributes(typeof(ImportAttribute), true).Any();
        }
    }
