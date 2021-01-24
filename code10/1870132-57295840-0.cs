    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Unload(WeakReference testAlcWeakRef, ref TestAssemblyLoadContext alc)
    {
        alc.Unload(); 
        alc = null;
        for (int i = 0; testAlcWeakRef.IsAlive && (i < 10); i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        Console.WriteLine($"is alive: {testAlcWeakRef.IsAlive}");
    }
