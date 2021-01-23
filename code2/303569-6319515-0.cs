    public static void PerformInvoke(Control ctrl, Action action)
    {
        if (ctrl.InvokeRequired)
            ctrl.Invoke(action);
        else
            action();
    }
