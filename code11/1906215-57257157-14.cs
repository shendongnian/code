    namespace WPFGreyButtonTest
    {
        public partial class InstrumentUserControl : PluginButton 
        {
            ...your existing code...
            public override string GetData()
            {
                return "Data from the Grey button";
            }
        }
    }
