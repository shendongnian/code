    using System;
    using System.Windows.Controls;
    
    namespace MainAppPlugins
    {
        public abstract class PluginButton : UserControl
        {
            public event EventHandler OnProcessedSomeData;
        }
    }
