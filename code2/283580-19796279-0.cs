    using System;
    using System.Globalization;
    using System.Windows.Data;
    namespace MyWpfLibrary
    {
        public class CultureAwareBinding : Binding
        {
            public CultureAwareBinding()
            {
                ConverterCulture = CultureInfo.CurrentCulture;
            }
        }
    }
