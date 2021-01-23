        private void button1_Click(object sender, EventArgs e) {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new
                System.Globalization.CultureInfo("fr-BE");
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            resources.ApplyResources(this, "$this");
            applyResources(resources, this.Controls);
        }
        private void applyResources(ComponentResourceManager resources, Control.ControlCollection ctls) {
            foreach (Control ctl in ctls) {
                resources.ApplyResources(ctl, ctl.Name);
                applyResources(resources, ctl.Controls);
            }
        }
