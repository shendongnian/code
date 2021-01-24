        public class OtherScript : MonoBehaviour
        {
            IEnumerator Start()
            {
                // starts an internet check and waits until it finished
                yield return CheckInternets.CheckConnection();
        
                if (CheckInternets.InternetON)
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
    
