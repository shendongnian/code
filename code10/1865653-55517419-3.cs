    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ServiceProcess;
    using System.Windows;
    
    namespace zzWpfApp2
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                List<string> computers = new List<string> { Environment.MachineName, Environment.MachineName };
                MenuItem root = new MenuItem() { Title = "General Menu" };
    
                foreach (string computer in computers)
                {
                    MenuItem childItem = new MenuItem() { Title = computer };
                    
                    foreach (ServiceController tempService in ServiceController.GetServices())
                    {
                        childItem.Items.Add(new MenuItem() { Title = tempService.DisplayName });
                    }
                    root.Items.Add(childItem);
                }
                trvMenu.Items.Add(root);
            }
            public class MenuItem
            {
                public MenuItem()
                {
                    this.Items = new ObservableCollection<MenuItem>();
                }
    
                public string Title { get; set; }
    
                public ObservableCollection<MenuItem> Items { get; set; }
            }
        }
    }
