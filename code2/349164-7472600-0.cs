    /// <summary>
    /// Processes Windows messages.
    /// </summary>
    /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override void WndProc(ref Message m) {
        if (m.Msg == (NativeMethods.WM_COMMAND + NativeMethods.WM_REFLECT) && NativeMethods.HIWORD(m.WParam) == NativeMethods.CBN_DROPDOWN) {
            // Wout: changed this to use BeginInvoke instead of calling ShowDropDown directly.
            // When calling directly, the Control doesn't receive focus.
            BeginInvoke(new MethodInvoker(ShowDropDown));
            return;
        }
        base.WndProc(ref m);
    }
