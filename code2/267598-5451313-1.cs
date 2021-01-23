    public class OutlookIF
    {
        // Attributs métiers       
        private Outlook.Application outlook;
        private String messageIDParam = "http://schemas.microsoft.com/mapi/proptag/0x1035001E";
        
        // Process watch
        private ManagementEventWatcher startWatch;
        private ManagementEventWatcher stopWatch;
        // Static Initialization Singleton Pattern
        private static readonly OutlookIF v_instance = new OutlookIF();
        public static OutlookIF Instance{get{return v_instance;}}
        
        private OutlookIF()
        {
            // Création des processWatchers
            startWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace WHERE ProcessName = 'OUTLOOK.EXE'"));
            stopWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace WHERE ProcessName = 'OUTLOOK.EXE'"));      
        }
        
        //Tentative de connexion à Outlook
        public void tryHook()
        {
            while(true)
            {
                if (Process.GetProcessesByName("outlook").Length == 0)
                    startWatch.WaitForNextEvent();
                try
                {
                    this.outlook = new Outlook.ApplicationClass();      
                    this.outlook.ItemContextMenuDisplay += new Outlook.ApplicationEvents_11_ItemContextMenuDisplayEventHandler(addEntrytoContextMenu);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                stopWatch.WaitForNextEvent();
                Marshal.FinalReleaseComObject(this.outlook);
                this.outlook = null;
            }  
        }
    }
