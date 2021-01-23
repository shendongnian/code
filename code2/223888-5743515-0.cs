    namespace dk_admin_site.Calculations
    {
        public partial class AssignedFieldCalculation : System.Web.UI.UserControl
        {
            public static AssignedFieldCalculation LoadControl(Calculation initialData)
            {
                var myControl = (AssignedFieldCalculation) ((Page) HttpContext.Current.Handler).LoadControl(@"~\\Calculations\AssignedFieldCalculation.ascx");
                myControl._initialData = initialData;
                return myControl;
            }
            
            private Calculation _initialData;
            public Calculation Data { get { return _initialData; } }
            protected void Page_Load(object sender, EventArgs e) {}
        }
    }
