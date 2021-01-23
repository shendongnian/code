    if (subprocess == null || !subprocess.IsAlive)
    {                                            
        subprocess = new Thread(processor.run);
        subprocess.IsBackground = true;
        subprocess.Start();
    }
