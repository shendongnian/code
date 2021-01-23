    [PermissionSetAttribute(SecurityAction.Demand, Unrestricted = true)]
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        if (m.Msg == (int)NativeMethods.WindowMessage.GETOBJECT)
        {
            if (m.LParam.ToInt32() == AutomationInteropProvider.RootObjectId)
            {
                m.Result = AutomationInteropProvider.ReturnRawElementProvider(
                    Handle, m.WParam, m.LParam, (IRawElementProviderSimple)this);
    
                return;
            }
            else if (m.LParam == (IntPtr)NativeMethods.OBJID_NATIVEOM)
            {
                IntPtr handle = Marshal.GetComInterfaceForObject(this, typeof(NativeMethods.IOleCommandTarget));
                Guid unknownGuid = typeof(NativeMethods.IUnknown).GUID;
                m.Result = NativeMethods.LresultFromObject(ref unknownGuid, m.WParam, handle);
                return;
            }
        }
        base.WndProc(ref m);
    }
