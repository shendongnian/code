    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Advertisements;
    
    public class AdMo : MonoBehaviour
    {
        string gameId = "1234567";
        bool testMode = true;
        // Initialize the Ads service:
        void Start () {
            Advertisement.Initialize (gameId, testMode);
        }
        public void showADD()
        {
            if(Advertisement.IsReady()){
                Advertisement.Show();
                Debug.Log("this");
            } else {
                Debug.Log("that"); //this will return instead (see image below)
            }
        }
    }
