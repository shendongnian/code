    public class ExclamationMarkSpawn : MonoBehaviour 
    {
        public Transform spawnPos;
        public GameObject exclamationMark;
        public GameObject exclamationMarkAudio;
    
        [SerializeField] private CameraShake cameraShake;
    
        // only serialized for debug
        [SerializeField] private bool isShowingExclamation;
        private void Awake()
        {
            if(!cameraShake) cameraShake = Camera.main.GetComponent<CameraShake>();
    
            // or assuming this component exists only once in the entire scene anyway
            if(!cameraShake) cameraShake = FindObjectOfType<CameraShake>();
        }
    
        public void SpawnExclamationMark()
        {
            StartCoroutine(cameraShake.Shake(0.2f, 0.2f, 0.2f));
            
            StartCoroutine(DestroyExclamationMark());
        }
    
        private IEnumerator DestroyExclamationMark()
        {
            // block concurrent routine call
            if(isShowingExclamation) yield brake;
            // set flag blocking concurrent routines
            isShowingExclamation = true;
            Instantiate(exclamationMark, spawnPos.position, Quaternion.identity);
            if (exclamationMarkAudio) Instantiate(exclamationMarkAudio, spawnPos.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
            var children = new List<GameObject>();
            foreach (var child in transform.ToList()) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
            // give the flag free
            isShowingExclamation = false;
        }
    }
