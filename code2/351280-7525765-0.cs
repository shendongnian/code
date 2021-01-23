    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    namespace WindowsFormsControlLibrary1 {
        public partial class DebugControl : UserControl {
            public DebugControl() {
                InitializeComponent();
            }
            public override ISite Site
            {
                get
                {
                    return base.Site;
                }
                set
                {
                    base.Site = value;
                    IComponentChangeService service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                    service.ComponentAdding += (sender, e) => {
                        IDesignerHost host = (IDesignerHost)value.Container;
                        Component component = (Component)host.RootComponent;
                        if (component as Form != null)
                        {
                            Form form = (Form)component;
                            foreach (Control c in form.Controls)
                            {
                                if (c.GetType() == this.GetType())
                                {
                                    throw new System.ArgumentException("You cannot add two of these controls to a form!");
                                }
                            }
                        }
                    };
                }
            }
        }
    }
