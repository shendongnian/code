    private void UpdateSystemDiagnostics()
    {
        SystemDiagnostic[0] = _cpuLoad.NextValue();
        SystemDiagnostic[1] = _ramFree.NextValue();
     this.Invoke(new MethodInvoker(delegate
                {
                    _labelCpuStatus.Text = string.Format("CPU LOAD: ") + string.Format("{0:0.##}%", SystemDiagnostic[0]).PadRight(8);
        _labelMemoryStatus.Text = string.Format("FREE MEMORY: {0}MB", SystemDiagnostic[1]);
                }));
        
    }
