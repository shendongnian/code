    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.ComponentModel.Design;
    namespace VSDesignHost
    {
    class StringManager : Component
    {
        private ContainerControl _containerControl = null;
        public StringManager()
        {
            TheList = new List<string>();
        }
        public StringManager(IContainer container) : this()
        {
            container.Add(this);
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            //Whatever
        }
        public ContainerControl ContainerControl
        {
            get { return _containerControl; }
            set { _containerControl = value; }
        }
        public override ISite Site
        {
            set
            {
                base.Site = value;
                if (value != null)
                {
                    IDesignerHost host = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    if (host != null)
                    {
                        IComponent rootComponent = host.RootComponent;
                        if (rootComponent is ContainerControl)
                        {
                            this.ContainerControl = (ContainerControl)rootComponent;
                        }
                    }
                }
            }
        }
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public List<string> TheList { get; set; }
    }
    }
