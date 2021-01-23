    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Microsoft.Win32.SafeHandles;
    
    using BOOL = System.Boolean;
    using DWORD = System.UInt32;
    using HHOOK = SafeHookHandle;
    using HINSTANCE = System.IntPtr;
    using HOOKPROC = HookProc;
    using LPARAM = System.IntPtr;
    using LRESULT = System.IntPtr;
    using POINT = System.Drawing.Point;
    using ULONG_PTR = System.IntPtr;
    using WPARAM = System.IntPtr;
    
    public delegate LRESULT HookProc(int nCode, WPARAM wParam, LPARAM lParam);
    
    internal static class NativeMethods
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern HHOOK SetWindowsHookEx(
            HookType idHook,
            HOOKPROC lpfn,
            HINSTANCE hMod,
            DWORD dwThreadId);
    
        [DllImport("User32.dll")]
        internal static extern LRESULT CallNextHookEx(
            HHOOK hhk,
            int nCode,
            WPARAM wParam,
            LPARAM lParam);
    
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern BOOL UnhookWindowsHookEx(
            IntPtr hhk);
    }
    
    internal static class NativeTypes
    {
        internal enum MSLLHOOKSTRUCTFlags : uint
        {
            LLMHF_INJECTED = 0x00000001U,
        }
    
        [StructLayout(LayoutKind.Sequential)]
        internal struct MSLLHOOKSTRUCT
        {
            internal POINT pt;
            internal DWORD mouseData;
            internal MSLLHOOKSTRUCTFlags flags;
            internal DWORD time;
            internal ULONG_PTR dwExtraInfo;
        }
    }
    
    internal static class NativeConstants
    {
        internal const int WH_MOUSE_LL = 14;
    
        internal const int HC_ACTION = 0;
    
        internal const int WM_MOUSEWHEEL = 0x020A;
        internal const int WM_MOUSEHWHEEL = 0x020E;
    
        internal const int WHEEL_DELTA = 120;
    }
    
    public enum HookType : int
    {
        LowLevelMouseHook = NativeConstants.WH_MOUSE_LL
    }
    
    public enum HookScope : int
    {
        LowLevelGlobal,
    }
    
    public class SafeHookHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeHookHandle() : base(true) { }
    
        public static SafeHookHandle SetWindowsHook(HookType idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId)
        {
            var hhk = NativeMethods.SetWindowsHookEx(idHook, lpfn, hMod, dwThreadId);
    
            if (hhk.IsInvalid)
            {
                throw new Win32Exception();
            }
            else
            {
                return hhk;
            }
        }
    
        public IntPtr CallNextHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return NativeMethods.CallNextHookEx(this, nCode, wParam, lParam);
        }
    
        protected override bool ReleaseHandle()
        {
            return NativeMethods.UnhookWindowsHookEx(this.handle);
        }
    }
    
    public abstract class WindowsHook : IDisposable
    {
        private SafeHookHandle hhk;
        private HookProc lpfn;
    
        protected WindowsHook(HookType idHook, HookScope scope)
        {
            this.lpfn = this.OnWindowsHook;
    
            switch (scope)
            {
                case HookScope.LowLevelGlobal:
                    this.hhk = SafeHookHandle.SetWindowsHook(idHook, this.lpfn, IntPtr.Zero, 0U);
                    return;
                default:
                    throw new InvalidEnumArgumentException("scope", (int)scope, typeof(HookScope));
            }
        }
    
        protected virtual IntPtr OnWindowsHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return this.hhk.CallNextHook(nCode, wParam, lParam);
        }
    
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.hhk != null) { this.hhk.Dispose(); }
            }
        }
    }
    
    public class LowLevelMouseHook : WindowsHook
    {
        public event MouseEventHandler MouseWheel;
    
        public LowLevelMouseHook() : base(HookType.LowLevelMouseHook, HookScope.LowLevelGlobal) { }
    
        protected sealed override IntPtr OnWindowsHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == NativeConstants.HC_ACTION)
            {
                var msLLHookStruct = (NativeTypes.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(NativeTypes.MSLLHOOKSTRUCT));
    
                switch (wParam.ToInt32())
                {
                    case NativeConstants.WM_MOUSEWHEEL:
                    case NativeConstants.WM_MOUSEHWHEEL:
                        this.OnMouseWheel(new MouseEventArgs(Control.MouseButtons, 0, msLLHookStruct.pt.X, msLLHookStruct.pt.Y, (int)msLLHookStruct.mouseData >> 16));
                        break;
                }
            }
    
            return base.OnWindowsHook(nCode, wParam, lParam);
        }
    
        protected virtual void OnMouseWheel(MouseEventArgs e)
        {
            if (this.MouseWheel != null)
            {
                this.MouseWheel(this, e);
            }
        }
    }
  
