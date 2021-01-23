    public class MemoryInstance : Memory
    {
      private var m_instanceProcessId;
      public MemoryInstance(var processId) : base()
      {
        m_instanceProcessId = processId;
      }
      public void OpenProcess()
      {
        Memory.OpenProcess(m_instanceProcessId);
      }
    }
    public class HookInstance: Hook
    {
      private var m_hookId;
      public HookInstance(var hookId) : base()
      {
        m_hookId = hookId;
      }
      public void Apply()
      {
        Hook.Apply(m_hookId);
      }
    }
