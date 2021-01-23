    using System.Linq;
    namespace WpfApplication4
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                using (var db = new PlatEntities())
                {
                    PacketEPD pd = (from epd in db.PacketEPD
                                    select epd).First();
                    pd.ChangeTracker.ChangeTrackingEnabled = true;
                    pd.EDNo = "1";
                    pd.RejectChanges();
                }
            }
        }
    }
