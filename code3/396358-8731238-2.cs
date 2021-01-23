    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WinFormsSystemMenuTest
    {
        public partial class Form1 : Form
        {
            #region Win32 API Stuff
    
            // Define the Win32 API methods we are going to use
            [DllImport("user32.dll")]
            private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    
            [DllImport("user32.dll")]
            private static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);
    
            /// Define our Constants we will use
            public const Int32 WM_SYSCOMMAND = 0x112;
            public const Int32 MF_SEPARATOR = 0x800;
            public const Int32 MF_BYPOSITION = 0x400;
            public const Int32 MF_STRING = 0x0;
            
            #endregion
            
            // The constants we'll use to identify our custom system menu items
            public const Int32 _SettingsSysMenuID = 1000;
            public const Int32 _AboutSysMenuID = 1001;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnHandleCreated(EventArgs e)
            {
                /// Get the Handle for the Forms System Menu
                IntPtr systemMenuHandle = GetSystemMenu(this.Handle, false);
    
                /// Create our new System Menu items just before the Close menu item
                InsertMenu(systemMenuHandle, 5, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty); // <-- Add a menu seperator
                InsertMenu(systemMenuHandle, 6, MF_BYPOSITION, _SettingsSysMenuID, "Settings...");
                InsertMenu(systemMenuHandle, 7, MF_BYPOSITION, _AboutSysMenuID, "About...");
                base.OnHandleCreated(e);
            }
    
            protected override void WndProc(ref Message m)
            {
                // Check if a System Command has been executed
                if (m.Msg == WM_SYSCOMMAND)
                {
                    // Execute the appropriate code for the System Menu item that was clicked
                    switch (m.WParam.ToInt32())
                    {
                        case _SettingsSysMenuID:
                            MessageBox.Show("\"Settings\" was clicked");
                            break;
                        case _AboutSysMenuID:
                            MessageBox.Show("\"About\" was clicked");
                            break;
                    }
                }
                
                base.WndProc(ref m);
            }
        }
    }
