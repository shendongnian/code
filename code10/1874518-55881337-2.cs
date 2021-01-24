    namespace SampleWinApp
    {
    #if DEBUG
        public partial class MyControl : NonAbstractcBase
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
        public class NonAbstractcBase : BaseControl { }
    #endif
    }
