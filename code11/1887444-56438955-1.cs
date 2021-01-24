    public class TimeScaler : MonoBehaviour
    {
        // adjust in Inspector
        public float initialTimeScale = 1.0f;
        private void Start()
        {
            SetTimeScale(initialTimeScale);
        }
        // Can now also be called rom other scripts
        public void SetTimeScale(float scale)
        {
            Time.timeScale = scale;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
