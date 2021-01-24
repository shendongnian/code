    public class TapListener : MonoBehaviour, IMixedRealityGestureHandler
    {
        [SerializeField]
        private MixedRealityInputAction selectAction; // You'll need to set this in the Inspector to Select
        private void OnEnable()
        {
            CoreServices.InputSystem?.RegisterHandler<IMixedRealityGestureHandler>(this);
        }
        private void OnDisable()
        {
            CoreService.InputSystem?.UnregisterHandler<IMixedRealityGestureHandler>(this);
        }
        public void OnGestureCompleted(InputEventData eventData)
        {
            if (eventData.MixedRealityInputAction == selectAction)
            {
                Debug.Log("Tap!");
            }
        }
        public void OnGestureStarted(InputEventData eventData) { }
        public void OnGestureUpdated(InputEventData eventData) { }
        public void OnGestureCanceled(InputEventData eventData) { }
    }
