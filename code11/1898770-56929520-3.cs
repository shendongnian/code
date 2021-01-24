    using System;
    using System.Diagnostics;
    using System.Linq;
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    sealed class UseViewModelAttribute : Attribute
    {
        public Type ViewModelType { get; }
        public UseViewModelAttribute(Type viewModelType)
        {
            Debug.Assert(typeof(IViewModel).IsAssignableFrom(viewModelType));
            ViewModelType = viewModelType;
        }
    }
    
    class ViewModelFactory
    {
        private readonly static Type[] ctorParams = new Type[] { typeof(IProduct) };
        public IViewModel CreateViewModel(IProduct product)
        {
            var vmType = (product.GetType().GetCustomAttributes(false).FirstOrDefault(attr
                => attr is UseViewModelAttribute) as UseViewModelAttribute)?.ViewModelType;
            Debug.Assert(!(vmType is null));
            return Activator.CreateInstance(vmType, product) as IViewModel;
        }
    }
