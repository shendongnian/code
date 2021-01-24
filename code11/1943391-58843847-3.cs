    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms.Design;
    
    public class TypeDescriptorFilterService : ITypeDescriptorFilterService
    {
        internal TypeDescriptorFilterService()
        {
        }
    
        private IDesigner GetDesigner(IComponent component)
        {
            ISite site = component.Site;
            if (site != null)
            {
                IDesignerHost service = site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (service != null)
                    return service.GetDesigner(component);
            }
            return (IDesigner)null;
        }
    
        bool ITypeDescriptorFilterService.FilterAttributes(IComponent component, IDictionary attributes)
        {
            if (component == null)
                throw new ArgumentNullException("component");
            if (attributes == null)
                throw new ArgumentNullException("attributes");
            IDesigner designer = this.GetDesigner(component);
            if (designer is IDesignerFilter)
            {
                ((IDesignerFilter)designer).PreFilterAttributes(attributes);
                ((IDesignerFilter)designer).PostFilterAttributes(attributes);
            }
            return designer != null;
        }
    
        bool ITypeDescriptorFilterService.FilterEvents(IComponent component, IDictionary events)
        {
            if (component == null)
                throw new ArgumentNullException("component");
            if (events == null)
                throw new ArgumentNullException("events");
            IDesigner designer = this.GetDesigner(component);
            if (designer is IDesignerFilter)
            {
                ((IDesignerFilter)designer).PreFilterEvents(events);
                ((IDesignerFilter)designer).PostFilterEvents(events);
            }
            return designer != null;
        }
    
        bool ITypeDescriptorFilterService.FilterProperties(IComponent component, IDictionary properties)
        {
            if (component == null)
                throw new ArgumentNullException("component");
            if (properties == null)
                throw new ArgumentNullException("properties");
    
            IDesigner designer = this.GetDesigner(component);
            if (designer is IDesignerFilter)
            {
                ((IDesignerFilter)designer).PreFilterProperties(properties);
                ((IDesignerFilter)designer).PostFilterProperties(properties);
            }
    
            return designer != null;
        }
    }
    
    public class MyDesignSurface : DesignSurface
    {
        public MyDesignSurface() : base()
        {
            this.ServiceContainer.RemoveService(typeof(ITypeDescriptorFilterService));
            this.ServiceContainer.AddService(typeof(ITypeDescriptorFilterService), new TypeDescriptorFilterService());
        }
    
        protected override void OnLoaded(LoadedEventArgs e)
        {
            base.OnLoaded(e);
            var svc = (IExtenderProviderService)this.ServiceContainer.GetService(typeof(IExtenderProviderService));
            var providers = (ArrayList)svc.GetType().GetField("_providers",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance).GetValue(svc);
            foreach (IExtenderProvider p in providers.ToArray())
                if (p.ToString().Contains("NameExtenderProvider") ||
                   p.ToString().Contains("NameInheritedExtenderProvider"))
                    svc.RemoveExtenderProvider(p);
    
            svc.AddExtenderProvider(new NameExtenderProvider());
            svc.AddExtenderProvider(new NameInheritedExtenderProvider());
        }
    }
    
    
    [ProvideProperty("Name", typeof(IComponent))]
    public class NameExtenderProvider : IExtenderProvider
    {
        private IComponent baseComponent;
    
        internal NameExtenderProvider()
        {
        }
    
        protected IComponent GetBaseComponent(object o)
        {
            if (this.baseComponent == null)
            {
                ISite site = ((IComponent)o).Site;
                if (site != null)
                {
                    IDesignerHost service = (IDesignerHost)site.GetService(typeof(IDesignerHost));
                    if (service != null)
                        this.baseComponent = service.RootComponent;
                }
            }
            return this.baseComponent;
        }
    
        public virtual bool CanExtend(object o)
        {
            return this.GetBaseComponent(o) == o || TypeDescriptor.GetAttributes(o)[typeof(InheritanceAttribute)].Equals((object)InheritanceAttribute.NotInherited);
        }
    
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [ParenthesizePropertyName(true)]
        [MergableProperty(false)]
        [Category("Design")]
        [Browsable(false)]
        public virtual string GetName(IComponent comp)
        {
            ISite site = comp.Site;
            if (site != null)
                return site.Name;
            return (string)null;
        }
    
        public void SetName(IComponent comp, string newName)
        {
            ISite site = comp.Site;
            if (site == null)
                return;
            site.Name = newName;
        }
    
        public class MyFormDesigner : DocumentDesigner
        {
    
        }
    }
    
    public class NameInheritedExtenderProvider : NameExtenderProvider
    {
        internal NameInheritedExtenderProvider()
        {
        }
        public override bool CanExtend(object o)
        {
            return this.GetBaseComponent(o) != o && !TypeDescriptor.GetAttributes(o)[typeof(InheritanceAttribute)].Equals((object)InheritanceAttribute.NotInherited);
        }
    
        [ReadOnly(true)]
        public override string GetName(IComponent comp)
        {
            return base.GetName(comp);
        }
    }
