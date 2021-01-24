`
    public class ScaleWithSlider : MonoBehaviour
    {
        public Slider z;
        public Slider x;
        private bool _respondsToSlider;
        private ConveyorController _conveyorController;
        private void Start()
        {
            _conveyorController = GetComponentInParent<ConveyorController>();
        }
        void Update()
        {
            if (!_respondsToSlider) return;
            
            transform.localScale = new Vector3(x.value, 25f, z.value);
        }
        public void SetRespondsToSlider(bool respondsToSlider)
        {
            _respondsToSlider = respondsToSlider;
        }
        private void OnMouseDown()
        {
            // any other way of getting the active conveyor would also work
            _conveyorController.SetActiveConveyor(this);
        }
`
The Controller class makes sure only one conveyer is active:
`
    public class ConveyorController : MonoBehaviour
    {
        // this list must filled somehow. best would be right after Instantiating the conveyer.
        private List<ScaleWithSlider> _allSliderScalers;
        public void SetActiveConveyor(ScaleWithSlider scaleWithSlider)
        {
            foreach (var conveyor in _allSliderScalers)
            {
                conveyor.SetRespondsToSlider(conveyor == scaleWithSlider);
            }
        }
    }
`
