            // load your dll
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom("SomeUserControl.dll");
            // to get the right type use namespace.controlname
            Type type = assembly.GetType("MyControlLibrary.MyUserCtl");
            // create an instance
            object instanceOfMyType = Activator.CreateInstance(type);
            // do something with Control
            Control ctrl = instanceOfMyType as Control;
            if (ctrl != null)
            {
                this.Controls.Add(ctrl);
                ctrl.Dock = DockStyle.Bottom;
            }
