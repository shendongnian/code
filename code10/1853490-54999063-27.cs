        public class OtherScript : MonoBehaviour
        {
            private void Start()
            {
                // somehow get a reference instead of using static
                // that's always the cleaner way
                var check = FindObjectOfType<CheckInternets>();
        
                // starts an internet check
                check?.CheckConnection(OnConnectionCheckFinished);
            }
        
            private void OnConnectionCheckFinished(bool isConnected)
            {
                if (isConnected)
                {
                    //do some stuff
                    Debug.Log("OTHER Script Check :: Online! :)");
                }
                else
                {
                    //do some other stuff
                    Debug.Log("OTHER Script Check :: Offline! :(");
                }
            }
        }
