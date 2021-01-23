    public interface IControllerBase {
        event MyEventHandler MyEvent;
        bool EnableDTMFDetection(string CallID, Party Party);
        bool DisableDTMFDetection(string CallID, Party Party);
    }
    public PlatformOne : IControllerBase
        // yadda yadda...
        public event MyEventHandler MyEvent;
        // members of PlatformOne can invoke MyEvent as a normal delegate
    }
