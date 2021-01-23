    public class CameraManager
    {
        private Dictionary<Type, ICamera> _cameras;
        private ICamera _current;
        public ICamera Current
        {
            get
            {
                return _current;
            }
        }
        // Sets the current cammera to the internal instance of the camera type
        public void SetCurrent<T>() where T : ICamera
        {
            if (!_cameras.ContainsKey(typeof(T)))
            {
                // TODO: Instantiate a new camera class here...
            }
            _current = _cameras[typeof(T)];
        }
    }
