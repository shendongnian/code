    namespace Test
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainViewModel();
            }
    
            private void Var_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                
            }
        }
    
    
        public class MainViewModel : INotifyPropertyChanged
        {
            public MainViewModel()
            {
                BindItems();
            }
    
            private List<string> _properties;
    
            public List<string> Properties
            {
                get { return _properties; }
                set
                {
                    if (value.Equals(_properties))
                        return;
                    _properties = value;
                    OnPropertyChanged(nameof(Properties));
                }
            }
    
            private void BindItems()
            {
                string[] items =
                {
                    "BlackOilFluid",
                    "Boundary",
                    "Casing",
                    "CheckValve",
                    "Choke",
                    "Completion",
                    "CompletionConingPoint",
                    "CompletionModel",
                    "CompositionalFluid",
                    "Compressor",
                    "EngineKeywords",
                    "ESP",
                    "Expander",
                    "FileBasedFluid",
                    "Flowline",
                    "FluidComponent",
                    "GasLiftInjection",
                    "GenericBooster",
                    "GenericEquipment",
                    "GravelPack",
                    "HeatExchanger",
                    "Injector",
                    "IPRBackPressure",
                    "IPRDarcy",
                    "IPRFetkovitch",
                    "IPRForchheimer",
                    "IPRHorizontalPI",
                    "IPRHydraulicFracture",
                    "IPRJones",
                    "IPRPIModel",
                    "IPRPSSBabuOdeh",
                    "IPRSSJoshi",
                    "IPRVogel",
                    "Junction",
                    "Liner",
                    "MeasurementPoint",
                    "MFLFluid",
                    "MultiphaseBooster",
                    "MultiplierAdder",
                    "NetworkSim",
                    "NodalAnalysisOp",
                    "OneSubseaBooster",
                    "OpenHole",
                    "Packer",
                    "PCP",
                    "PTProfileSim",
                    "Pump",
                    "PVTFluid",
                    "RodPump",
                    "SinglephaseSeparator",
                    "Sink",
                    "SlidingSleeve",
                    "Source",
                    "Study",
                    "SubsurfaceSafetyValve",
                    "ThreePhaseSeparator",
                    "Tubing",
                    "TubingPlug",
                    "TwoPhaseSeparator",
                    "WaterTempVelocitySurvey",
                    "Well",
                    "WetGasCompressor"
                };
    
                Properties = new List<string>(items);
            }
    
            #region INotifyPropertyChanged
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #endregion
        }
    }
