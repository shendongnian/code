    /// <summary>
    /// Interaction logic for ModuleBRibbonTab.xaml
    /// </summary>
    public partial class ModuleBRibbonTab :  IRegionMemberLifetime
    {
        #region Constructor
        public ModuleBRibbonTab()
        {
            InitializeComponent();
        }
        #endregion
        #region IRegionMemberLifetime Members
        public bool KeepAlive
        {
            get { return false; }
        }
        #endregion
    }
