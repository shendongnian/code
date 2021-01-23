    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using UINT = System.UInt32;
    using HMENU = System.IntPtr;
    using HBITMAP = System.IntPtr;
    using DWORD = System.UInt32;
    using LPTSTR = System.IntPtr;
    namespace MenuTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                contextMenu.MenuItems.Add(new MenuItem() { Text = "Item A" });
                contextMenu.MenuItems.Add(new MenuItem() { Text = "Item B" });
                contextMenu.MenuItems.Add(new MenuItem() { Text = "Item C" });
                contextMenu.MenuItems.Add(new MenuItem() { Text = "Item D" });
                this.MouseDown += new MouseEventHandler(Form1_MouseDown);
                contextMenu.Popup += new EventHandler(contextMenu_Popup);
            }
            void contextMenu_Popup(object sender, EventArgs e)
            {
                var type = contextMenu.GetType();
                var members = type.GetMembers(
                              BindingFlags.NonPublic | BindingFlags.Instance);
                var menuMember = type.GetField("m_hmnu", 
                                 BindingFlags.NonPublic | BindingFlags.Instance);
                var hMenu = (HMENU)menuMember.GetValue(contextMenu);
                var info = new MENUITEMINFO();
                info.cbSize = (uint)Marshal.SizeOf(info);
                info.fMask = MIIM_STATE;
                var result = GetMenuItemInfo(hMenu, 0, true, out info);
                if (!result)
                {
                    var err = Marshal.GetLastWin32Error();
                    if (err == 0x0579) MessageBox.Show("Invalid menu handle");
                    return;
                }
                info.fMask = MIIM_STATE;
                info.fState &= (~MFS_HILITE);
                result = SetMenuItemInfo(hMenu, 0, true, ref info); 
            }
            void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                contextMenu.Show(this, new Point(e.X, e.Y));
            }
            private const uint MIIM_STATE = 1;
            private const uint MFS_UNHILITE = 0;
            private const uint MFS_HILITE = 0x80;        
            //typedef struct tagMENUITEMINFO {
            //  UINT cbSize; 
            //  UINT fMask; 
            //  UINT fType; 
            //  UINT fState; 
            //  UINT wID; 
            //  HMENU hSubMenu; 
            //  HBITMAP hbmpChecked; 
            //  HBITMAP hbmpUnchecked; 
            //  DWORD dwItemData; 
            //  LPTSTR dwTypeData; 
            //  UINT cch; 
            //} MENUITEMINFO, FAR* LPMENUITEMINFO; 
            private struct MENUITEMINFO
            {
                public UINT cbSize;
                public UINT fMask;
                public UINT fType;
                public UINT fState;
                public UINT wID;
                public HMENU hSubMenu;
                public HBITMAP hbmpChecked;
                public HBITMAP hbmpUnchecked;
                public DWORD dwItemData;
                public LPTSTR dwTypeData;
                public UINT cch; 
            }
            //BOOL SetMenuItemInfo(
            //  HMENU hMenu,
            //  UINT uItem,
            //  BOOL fByPosition,
            //  LPCMENUITEMINFO lpmii
            //);
            [DllImport("coredll", SetLastError = true)]
            private static extern bool SetMenuItemInfo(HMENU hMenu, UINT uItem, 
                                       [MarshalAs(UnmanagedType.Bool)]bool fByPosition, 
                                       ref MENUITEMINFO lpmii);
            //BOOL GetMenuItemInfo(
            //  HMENU hMenu,
            //  UINT uItem,
            //  BOOL fByPosition,
            //  LPMENUITEMINFO lpmii
            //);
            [DllImport("coredll", SetLastError = true)]
            private static extern bool GetMenuItemInfo(HMENU hMenu, UINT uItem, 
                                       [MarshalAs(UnmanagedType.Bool)]bool fByPosition, 
                                       out MENUITEMINFO lpmii);
            //HMENU GetSubMenu(
            //  HMENU hMenu,
            //  int nPos
            //);
            [DllImport("coredll", SetLastError = true)]
            private static extern HMENU GetSubMenu(HMENU hMenu, int nPos);
        }
    }
