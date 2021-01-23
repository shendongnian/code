        public static System.Windows.Controls.UserControl GetTemplateFromObject(object o)
        {
            System.Windows.Controls.UserControl template = null;
            try
            {
                ViewModelBase vm = o as ViewModelBase;
                if (vm != null && !vm.CanUserLoad())
                    return new View.Core.SystemPages.SecurityPrompt(o);
                Type t = convertViewModelTypeToViewType(o.GetType());
                if (t != null)
                    template = Activator.CreateInstance(t) as System.Windows.Controls.UserControl;
                if (template == null)
                {
                    if (o is SearchablePage)
                        template = new View.Core.Pages.Generated.ViewList();
                    else if (o is MaintenancePage)
                        template = new View.Core.Pages.Generated.MaintenancePage(((MaintenancePage)o).EditingObject);
                }
                if (template == null)
                    throw new InvalidOperationException(string.Format("Could not generate PageTemplate object for '{0}'", vm != null && !string.IsNullOrEmpty(vm.PageKey) ? vm.PageKey : o.GetType().FullName));
            }
            catch (Exception ex)
            {
                BugReporter.ReportBug(ex);
                template = new View.Core.SystemPages.ErrorPage(ex);
            }
            return template;
        }
