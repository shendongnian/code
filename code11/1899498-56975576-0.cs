    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
<!---->
    public class StripLineTypeDescriptionProvider : TypeDescriptionProvider
    {
        public StripLineTypeDescriptionProvider()
           : base(TypeDescriptor.GetProvider(typeof(object))) { }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            ICustomTypeDescriptor baseDescriptor = base.GetTypeDescriptor(objectType, instance);
            return new StripLineTypeDescriptor(baseDescriptor);
        }
    }
