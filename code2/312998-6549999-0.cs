    using System;
    using System.Windows.Forms;
    namespace SimplePluginShared
    {
        public class PluginBase : Form
        {
            public virtual String GetStatus()
            {
                return null;
            }
        }
    }
