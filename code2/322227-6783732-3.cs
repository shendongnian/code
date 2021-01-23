    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.UI;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
            
                RegistryKey myKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\RunMRU");
                // Check to see if there were any subkeys
                if (myKey.SubKeyCount > 0)
                {
                    foreach (string subKey in myKey.GetSubKeyNames())
                    {
                        lbKeys.Items.Add(subKey);
                    }
                }
            }
    }
