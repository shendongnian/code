    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    public class MyDesignSurface : DesignSurface
    {
        public MyDesignSurface() : base()
        {
            this.ServiceContainer.RemoveService(typeof(ITypeDescriptorFilterService));
            this.ServiceContainer.AddService(typeof(ITypeDescriptorFilterService), new TypeDescriptorFilterService());
        }
    }
