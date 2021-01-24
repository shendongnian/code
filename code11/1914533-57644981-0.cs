    public class VisibilityChecker : MonoBehaviour
    {
        // E.g. using a read-only auto-property
        public bool IsVisible{ get; private set; }
        // If you rather like to be able to also see the value in the Inspector for debugging use
        //public bool IsVisible { get { return _isVisible;}}
        //[SerializeField] private bool _isVisible;
        private void OnBecameVisible()
        {
            IsVisible = true;
            //or
            //_isVisible = true;
        }
        private void OnBecameInvisible()
        {
            IsVisible = false;
            //or
            //_isVisible = false;
        }
    }
