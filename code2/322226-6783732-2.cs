    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.UI;
    using System.Web.UI.Controls;
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            
                RegistryKey myKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\RunMRU");
                // Check to see if there were any subkeys
                if (myKey.SubKeyCount > 0)
                {
                    foreach (string subKey in myKey.GetSubKeyNames())
                    {
                        lbKeys.Items.Add(new ListItem(subKey));
                    }
                }
            }
    }
