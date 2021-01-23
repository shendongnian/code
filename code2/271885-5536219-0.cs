      abstract class Base
        {
            public void ProcessMessages(IMessage[] messages)
            {
                PreProcess(messages);
    
                // Process.
    
                PostProcess(messages);
            }
    
            public virtual void PreProcess(IMessage[] messages)
            {
                // Base class does nothing.
            }
    
            public virtual void PostProcess(IMessage[] messages)
            {
                // Base class does nothing.
            }
        }
    
        class Derived : Base
        {
            public override void PostProcess(IMessage[] messages)
            {
                // Do something, log or whatever.
            }
    
            // Don't want to bother with pre-process.
        }
