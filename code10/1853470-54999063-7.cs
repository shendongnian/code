        public class OtherScript : MonoBehaviour
        {
            private IEnumerator Start()
            {
                // starts an internet check and waits until it finished
                yield return new WaitUntil(() => CheckInternets.IsFinished);
        
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
