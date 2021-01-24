    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    
    public class SceneChanger : MonoBehaviour
    {
        enum FadeStatus
        {
            fading_id,
            fading_out,
            none
        }
    
        public static SceneChanger Instance;
        public Image fadeImage;
        public float fadeDuration;
    
        private FadeStatus currentFadeStatus = FadeStatus.none;
        private float fadeTimer;
        private string sceneToLoad;
    
        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
    
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
                Destroy(gameObject);
    
            DontDestroyOnLoad(gameObject);
        }
    
    
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //scene loaded, running fade-in
            currentFadeStatus = FadeStatus.fading_id;
        }
    
        public void ChangeScene(string _name)
        {
            sceneToLoad = _name;
            currentFadeStatus = FadeStatus.fading_out;
        }
    
        void Update()
        {
            if(currentFadeStatus != FadeStatus.none)
            {
                fadeTimer += Time.deltaTime;
    
                if(fadeTimer > fadeDuration) //done fading
                {
                    fadeTimer = 0;
    
                    if (currentFadeStatus == FadeStatus.fading_out)
                    {
                        SceneManager.LoadScene(sceneToLoad);
                        fadeImage.color = Color.black;
                    }
                    else
                        fadeImage.color = Color.clear;
    
                    currentFadeStatus = FadeStatus.none;
                }
                else //still fading
                {
                    float alpha = 0;
                    if (currentFadeStatus == FadeStatus.fading_out)
                        alpha = Mathf.Lerp(0, 1, fadeTimer / fadeDuration);
                    else
                        alpha = Mathf.Lerp(1, 0, fadeTimer / fadeDuration);
    
                    fadeImage.color = new Color(0, 0,0, alpha);
                }
            }
        }
    }
