    public class CoalResarch : MonoBehaviour
    {
    
        bool CreatingWords = false;
        public bool timerIsDone = false;
        public static int hour = 1;
        public static int min = 0;
        public static int sec = 1;
        void Update()
        {
    
            if (CreatingWords == false)
            {
                CreatingWords = true;
                StartCoroutine(DisplayWoodMinningSec());
            }
    
        }
        public IEnumerator DisplayWoodMinningSec()
        { 
            while (hour>0 || min>0 || sec > 0)
            {
                //Timer
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ResearchScene"))
                {
                    GlobalResearch.CoalTimer.text = "0" + hour + ":" + min + ":" + Mathf.Round(sec);
                }
                yield return new WaitForSeconds(1);
                sec -= 1;
    
                if (sec < 0)
                {
                    sec = 59;
                    min -= 1;
                    if (min < 0)
                    {
                        hour -= 1;
                        min = 59;
                    }
                }
            }
            timerIsDone = true;
            Debug.Log("Finish!");
    
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ResearchScene"))
            {
                GlobalResearch.CoalTimer.text = "0" + hour + ":" + min + ":" + Mathf.Round(sec);
            }
            // GlobalResearch.CoalTimer.text = "Finished !";
            CreatingWords = false;
    
        }
    }
