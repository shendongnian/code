    public class LevelReader : MonoBehaviour
    {
        // ...
    
        void Start()
        {
            StartCoroutine(ReadLevelFileAfterFirstFrameCoroutine());
        }
    
        private IEnumerator ReadLevelFileAfterFirstFrameCoroutine()
        {
            yield return new WaitForEndOfFrame();
            // Call read level file.
        }
    
        // ...
    }
