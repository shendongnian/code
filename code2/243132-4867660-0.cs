    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    /// <summary>  
    /// Represents an ComboBox with additional properties for setting the   
    /// size of the AutoComplete Drop-Down window.  
    /// </summary>  
    public class ComboBoxEx : ComboBox
    {
    private int acDropDownHeight = 106;
    private int acDropDownWidth = 170;
    //<EditorBrowsable(EditorBrowsableState.Always), _  
    [Browsable(true), Description("The width, in pixels, of the auto complete drop down box"), DefaultValue(170)]
    public int AutoCompleteDropDownWidth
    {
        get { return acDropDownWidth; }
        set { acDropDownWidth = value; }
    }
    //<EditorBrowsable(EditorBrowsableState.Always), _  
    [Browsable(true), Description("The height, in pixels, of the auto complete drop down box"), DefaultValue(106)]
    public int AutoCompleteDropDownHeight
    {
        get { return acDropDownHeight; }
        set { acDropDownHeight = value; }
    }
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        ACWindow.RegisterOwner(this);
    }
    #region Nested type: ACWindow
    /// <summary>  
    /// Provides an encapsulation of an Auto complete drop down window   
    /// handle and window proc.  
    /// </summary>  
    private class ACWindow : NativeWindow
    {
        private static readonly Dictionary<IntPtr, ACWindow> ACWindows;
        #region "Win API Declarations"
        private const UInt32 WM_WINDOWPOSCHANGED = 0x47;
        private const UInt32 WM_NCDESTROY = 0x82;
        private const UInt32 SWP_NOSIZE = 0x1;
        private const UInt32 SWP_NOMOVE = 0x2;
        private const UInt32 SWP_NOZORDER = 0x4;
        private const UInt32 SWP_NOREDRAW = 0x8;
        private const UInt32 SWP_NOACTIVATE = 0x10;
        private const UInt32 GA_ROOT = 2;
        private static readonly List<ComboBoxEx> owners;
        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr GetAncestor(IntPtr hWnd, UInt32 gaFlags);
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        private static extern void GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
                                                uint uFlags);
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        #region Nested type: EnumThreadDelegate
        private delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);
        #endregion
        #region Nested type: RECT
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public readonly int Left;
            public readonly int Top;
            public readonly int Right;
            public readonly int Bottom;
            public Point Location
            {
                get { return new Point(Left, Top); }
            }
        }
        #endregion
        #endregion
        private ComboBoxEx owner;
        static ACWindow()
        {
            ACWindows = new Dictionary<IntPtr, ACWindow>();
            owners = new List<ComboBoxEx>();
        }
        /// <summary>  
        /// Creates a new ACWindow instance from a specific window handle.  
        /// </summary>  
        private ACWindow(IntPtr handle)
        {
            AssignHandle(handle);
        }
        /// <summary>  
        /// Registers a ComboBoxEx for adjusting the Complete Dropdown window size.  
        /// </summary>  
        public static void RegisterOwner(ComboBoxEx owner)
        {
            if ((owners.Contains(owner)))
            {
                return;
            }
            owners.Add(owner);
            EnumThreadWindows(GetCurrentThreadId(), EnumThreadWindowCallback, IntPtr.Zero);
        }
        /// <summary>  
        /// This callback will receive the handle for each window that is  
        /// associated with the current thread. Here we match the drop down window name   
        /// to the drop down window name and assign the top window to the collection  
        /// of auto complete windows.  
        /// </summary>  
        private static bool EnumThreadWindowCallback(IntPtr hWnd, IntPtr lParam)
        {
            if ((GetClassName(hWnd) == "Auto-Suggest Dropdown"))
            {
                IntPtr handle = GetAncestor(hWnd, GA_ROOT);
                if ((!ACWindows.ContainsKey(handle)))
                {
                    ACWindows.Add(handle, new ACWindow(handle));
                }
            }
            return true;
        }
        /// <summary>  
        /// Gets the class name for a specific window handle.  
        /// </summary>  
        private static string GetClassName(IntPtr hRef)
        {
            var lpClassName = new StringBuilder(256);
            GetClassName(hRef, lpClassName, 256);
            return lpClassName.ToString();
        }
        /// <summary>  
        /// Overrides the NativeWindow's WndProc to handle when the window  
        /// attributes changes.  
        /// </summary>  
        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_WINDOWPOSCHANGED))
            {
                // If the owner has not been set we need to find the ComboBoxEx that  
                // is associated with this dropdown window. We do it by checking if  
                // the upper-left location of the drop-down window is within the   
                // ComboxEx client rectangle.   
                if ((owner == null))
                {
                    Rectangle ownerRect = default(Rectangle);
                    var acRect = new RECT();
                    foreach (ComboBoxEx cbo in owners)
                    {
                        GetWindowRect(Handle, ref acRect);
                        ownerRect = cbo.RectangleToScreen(cbo.ClientRectangle);
                        if ((ownerRect.Contains(acRect.Location)))
                        {
                            owner = cbo;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    owners.Remove(owner);
                }
                if (((owner != null)))
                {
                    SetWindowPos(Handle, IntPtr.Zero, -5, 0, owner.AutoCompleteDropDownWidth,
                                 owner.AutoCompleteDropDownHeight, SWP_NOMOVE | SWP_NOZORDER | SWP_NOACTIVATE);
                }
            }
            if ((m.Msg == WM_NCDESTROY))
            {
                ACWindows.Remove(Handle);
            }
            base.WndProc(ref m);
        }
    }
    #endregion
    }
