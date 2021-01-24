    public Redirector : MonoBehaviour
    {
        // Either drag in via Inspector
        [SerializeField] private ScriptOnOtherObject _scriptOnOtherObject;
        // or get at runtime if you are always sure about the hierachy
        private void Awake()
        {
            _scriptOnOtherObject = transform.parent.GetComponent<ScriptOnOtherObject>();
        }
        // and now call this from the AnimationEvent
        public void DoIt()
        {
            _scriptOnOtherObject.TheMethodToCall();
        }
    }
