        protected override void OnLoad(EventArgs e) {
            foreach (Control ctl in this.Controls) {
                if (ctl is MdiClient) {
                    ctl.BackgroundImage = Properties.Resources.SampleImage;
                    break;
                }
            }
            base.OnLoad(e);
        }
