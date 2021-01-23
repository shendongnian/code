    Properties.Settings.Default.IsOptimizedForTracer !=Properties.Settings.Default.IsOptimizedForTracer;
    if (!Properties.Settings.Default.IsOptimizedForTracer)
    {
    btnOptimizeForTracer.Image = Properties.Resources.TracerOFF;
    return;
    }
    btnOptimizeForTracer.Image = Properties.Resources.TracerON;
