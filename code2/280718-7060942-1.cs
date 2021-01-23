    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    namespace VSDesignHost
    {
        class ComponentReader : Component, IStringManagerEnabled
        {
            private StringManager sm;
            public ComponentReader()
            {
                sm = null;
            }
            [Browsable(true), Category("MyCategory")]
            public StringManager StringManager
            {
                get { return sm; }
                set
                {
                    sm = value;
                }
            }
            [Browsable(true), Category("MyCategory"), TypeConverter(typeof(StringManagerStringConverter))]
            public string SelectedString { get; set; }
        }
    }
