    public class TimeScaler : MonoBehaviour
    {
        public float initialTimeScale;
        private void Start()
        {
            SetTimeScale(initialTimeScale);
        }
        public void SetTimeScale(float scale)
        {
            Time.timeScale = scale;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
