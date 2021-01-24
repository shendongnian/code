    [Serializeable]
    public class InteractionControllerEvent : UnityEvent<InteractionController> { }
    
    public class ExtendedInteractionBehaviour : InteractionBehaviour
    {
        public UnityEvent OnContactBeginEvent;
        public InteractionControllerEvent OnPerControllerContactBegin;
    
        // and just as before add those as callbacks to the actions
        private void Awake()
        {
            OnContactBegin -= OnContactBeginInvokeEvent;
            OnContactBegin += OnContactBeginInvokeEvent;
    
            OnPerControllerContactBegin -=
            OnPerControllerContactBegin += 
        }
    
        private void OnDestroy()
        {
            OnContactBegin -= OnContactBeginInvokeEvent;
        }
    
        private void OnContactBeginInvokeEvent()
        {
            OnContactBeginEvent?.Invoke();
        }
    
        private void OnPerControllerContactBeginInvokeEvent(InteractionController controller)
        {
            OnPerControllerContactBegin?.Invoke(controller);
        }
    }
