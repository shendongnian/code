    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.PointOfService;
    namespace POS
    {
    public class CashDrawerClass
    {
      CashDrawer myCashDrawer;
      PosExplorer explorer;
     public CashDrawerClass()
    {
     explorer = new PosExplorer(this);
     DeviceInfo ObjDevicesInfo = explorer.GetDevice("CashDrawer");
     myCashDrawer = explorer.CreateInstance(ObjDevicesInfo);
    }
     public void OpenCashDrawer()
      {
      myCashDrawer.Open();
      myCashDrawer.Claim(1000);
      myCashDrawer.DeviceEnabled = true;
      myCashDrawer.OpenDrawer();
      myCashDrawer.DeviceEnabled = false;
      myCashDrawer.Release();
      myCashDrawer.Close();
      }
    }
    }
