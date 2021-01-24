    namespace SampleWinApp
    {
    #if DEBUG
        public partial class MyControl : NonAbstractBase
    #else
        public partial class MyControl : BaseControl
    #endif
        {
            public MyControl()
            {
                InitializeComponent();
            }
        }
    #if DEBUG
        public class NonAbstractBase : BaseControl { }
    #endif
    }
