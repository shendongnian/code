    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Win32;
    
    private void btnenable_Click(object sender, EventArgs e)
    {
    const string keyName = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\USBSTOR";
    
    // int tLong = (int )Registry.GetValue(keyName, "Start",0);
    Registry.SetValue(keyName, "Start", "00000003");
    MessageBox.Show("USB MassStorage Enabled"); 
    
    }
    
    private void btndisable_Click(object sender, EventArgs e)
    {
    const string keyName = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\USBSTOR";
    
    // int tLong = (int )Registry.GetValue(keyName, "Start",0);
    Registry.SetValue(keyName, "Start", "00000004");
    MessageBox.Show("USB MassStorage Disabled"); 
    }
