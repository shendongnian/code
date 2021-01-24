    public class Spawner : MonoBehaviour
    {
        private float startTime;
        private float CurrentTime
        {
            get
            {
                return Time.time - startTime;
            }
        }
