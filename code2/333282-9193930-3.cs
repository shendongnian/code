    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Windows;
    using XamDataGridMasterDetail.ViewModels;
    using System.Collections.ObjectModel;
    using XamDataGridMasterDetail.Model;
    
    namespace XamDataGridMasterDetail
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
            {
                base.OnSessionEnding(e);
            }
    
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
    
                var view = new MainWindow();
                var vm = new MainViewModel();
                vm.Continents = new ObservableCollection<ContinentViewModel>();
                vm.Continents.Add(new ContinentViewModel
                {
                    Model = new Continent
                    {
                        Name = "Australasia",
                        Area = 100000,
                        Countries = new[] 
                        {
                            new Country 
                            {
                                Name="Australia",
                                Population=100
                            },
                            new Country
                            {
                                Name="New Zealand",
                                Population=200
                            }
                        }
                    }
                });
                vm.Continents.Add(new ContinentViewModel
                {
                    Model = new Continent
                    {
                        Name = "Europe",
                        Area = 1000000,
                        Countries = new[] 
                        {
                            new Country 
                            {
                                Name="UK",
                                Population=70000000
                            },
                            new Country
                            {
                                Name="France",
                                Population=50000000
                            },
                            new Country
                            {
                                Name="Germany",
                                Population=75000000
                            }
                        }
                    }
                });
                view.DataContext = vm;
                view.Show();
            }
    
        }
    }
