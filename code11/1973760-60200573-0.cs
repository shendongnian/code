        using System.Collections.Generic;
        using UnityEngine;
        
        public class PausedMenu : MonoBehaviour
        {
            public static bool Paused = false;
            public GameObject pauseUI;
        
            // Update is called once per frame
            void Update()
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (Paused)
                    {
                        ClickResumeButton();
                    }
                    else
                    {
                        ClickPauseButton();
                    }
                }
            }
        
            public void ClickResumeButton()
            {
                pauseUI.SetActive(false);
                Time.timeScale = 1f;
                Paused = false;
            }
        
            public void ClickPauseButton()
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0f;
                Paused = true;
            }
       }
