    public static void Main(String[] args)
    {
      MemoryInstance newMemory = new MemoryInstance(processes[1].Id);
      HookInstance newHook = new HookInstance(hookId);
      newMemory.OpenProcess();
      newHook.Apply();
    }
