    using System.Runtime.InteropServices; 
        //1-9-2013: so we can DISABLE COMPOSITING -- forcing Windows "Aero Glass" to revert to "Aero Basic"
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmEnableComposition(bool bEnable);
                DwmEnableComposition(false);    //DISABLE COMPOSITING -- forces Windows "Aero Glass" to revert to "Aero Basic"
                
