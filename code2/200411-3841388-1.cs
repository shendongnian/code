        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            string name = e.Node.Name;
            name = this.GetType().Namespace + "." + name;
            Type ctlType = System.Reflection.Assembly.GetExecutingAssembly().GetType(name);
            if (ctlType == null) e.Cancel = true;
            else {
                var ctor = ctlType.GetConstructor(new Type[] { });
                var ctl = ctor.Invoke(null) as UserControl;
                SelectView(ctl);
            }
        }
