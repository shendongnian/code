    public class Test : MonoBehaviour
    {
        private float _myTimer = 0;
    
        // Update is called once per frame
        void Update()
        {
            StartTimer(ref _myTimer);
    
            //_myTimer += Time.deltaTime;
        }
    
        private void StartTimer(ref float timer)
        {
            timer += Time.deltaTime;
        }
    }
