    public class PlayerControllerb : MonoBehaviour
    {
        [Header("Debug")]
        [SerializeField] private PlatformProvider platformProvider;
    
        private void OnSceneLoaded()
        {
            platforms = FindObjectOfType<PlatformProvider>();
        }
    
        // Set in the Inspector in Units per second
        public float Speed = 1;
    
        private int currentPlatformIndex;
    
        // Using this you can debug it in the context menu of the component without Arduino ;)
        [ContextMenu(nameof(GoToNextPlatform)>]
        public void GoToNextPlatform()
        {
            currentPlatformIndex++;
            currentPlatformIndex = Mathf.Min(currentPlatformIndex, platformProvider.platforms.Length - 1); 
    
            GoToPlatform (currentPlatformIndex);
        } 
    
        [ContextMenu (nameof(GoToPreviousPlatform))]
        public void GoToPreviousPlatform()
        {
            currentPlatformIndex--;
            currentPlatformIndex = Mathf.Max(currentPlatformIndex, 0);
    
            GoToPlatform (currentPlatformIndex);
        }
    
        private void GoToPlatform(int index)
        {
            // Depends on your needs
            // You can either use a bool and ignore concurrent routines
            // or simply stop any running one
            StopAllCoroutines();
            StartCoroutine(MoveTo(platformProvider.platforms [index].position));
        }
    
        private IEnumerator MoveRoutine (Vector3 target)
        {
            while(!Mathf.Approximately(0, Vector3.Distance(transform.position, target)))
            {
                yield return new WaitForFixedUpdate();
    
                rigidbody.MovePositio (Vector3.MoveTowards(rigidbody.position, target, Time.deltaTime * moveSpeed);
            }
        }
    }
