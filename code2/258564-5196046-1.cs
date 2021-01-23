            Type typen = typeof(Form);
            Assembly assem = typen.Assembly;
            //Assembly assem = Assembly.LoadFrom(typeof(Form).ToString());
            Type controlType = assem.GetType("System.Windows.Forms."+type); // GetType(controlType);
            object obj = Activator.CreateInstance(controlType);
            Control control = (Control)obj;
            return control;
