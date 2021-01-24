    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    public class FormTypeConverter : TypeConverter
    {
        public override bool GetStandardValuesExclusive
            (ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool CanConvertTo
            (ITypeDescriptorContext pContext, Type pDestinationType)
        {
            return base.CanConvertTo(pContext, pDestinationType);
        }
        public override object ConvertTo
            (ITypeDescriptorContext pContext, CultureInfo pCulture,
            object pValue, Type pDestinationType)
        {
            return base.ConvertTo(pContext, pCulture, pValue, pDestinationType);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext pContext,
            Type pSourceType)
        {
            if (pSourceType == typeof(string))
                return true;
            return base.CanConvertFrom(pContext, pSourceType);
        }
        public override object ConvertFrom
            (ITypeDescriptorContext pContext, CultureInfo pCulture, object pValue)
        {
            if (pValue is string)
                return GetTypeFromName(pContext, (string)pValue);
            return base.ConvertFrom(pContext, pCulture, pValue);
        }
        public override bool GetStandardValuesSupported
            (ITypeDescriptorContext pContext)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues
            (ITypeDescriptorContext pContext)
        {
            List<Type> types = GetProjectTypes(pContext);
            List<string> values = new List<string>();
            foreach (Type type in types)
                values.Add(type.FullName);
            values.Sort();
            return new StandardValuesCollection(values);
        }
        private List<Type> GetProjectTypes(IServiceProvider serviceProvider)
        {
            var typeDiscoverySvc = (ITypeDiscoveryService)serviceProvider
                .GetService(typeof(ITypeDiscoveryService));
            var types = typeDiscoverySvc.GetTypes(typeof(object), true)
                .Cast<Type>()
                .Where(item =>
                    item.IsPublic &&
                    typeof(Form).IsAssignableFrom(item) &&
                    !item.FullName.StartsWith("System")
                ).ToList();
            return types;
        }
        private Type GetTypeFromName(IServiceProvider serviceProvider, string typeName)
        {
            ITypeResolutionService typeResolutionSvc = (ITypeResolutionService)serviceProvider
                .GetService(typeof(ITypeResolutionService));
            return typeResolutionSvc.GetType(typeName);
        }
    }
