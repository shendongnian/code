    private uint lgLcdOnConfigureCB(int connection, System.IntPtr pContext)
    {
        form.Invoke(new MethodInvoker(() => OnConfigure(EventArgs.Empty)));
        return 0U;
    }
