    private void RussianFlag_Click(object sender, EventArgs e)
            {
                if (currentLanguage != "RUS")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    ChangeLanguage("ru-RU");
                }
            }
....
....
...
    private void ChangeLanguage(string lang)
            {
                foreach (Control c in this.Controls)
                {
                    ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
                    resources.ApplyResources(c, c.Name, new CultureInfo(lang));
                    if (c.ToString().StartsWith("System.Windows.Forms.GroupBox"))
                    {
                        foreach (Control child in c.Controls)
                        {
                            ComponentResourceManager resources_child = new ComponentResourceManager(typeof(Form1));
                            resources_child.ApplyResources(child, child.Name, new CultureInfo(lang));
                        }
                    }
                }
            }
