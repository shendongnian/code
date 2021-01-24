    using UnityEngine;
    using UnityEngine.UI;
    
    /// <summary>
    /// Display a text for 3 seconds in UI Text.
    /// </summary>
    class DisplayText : MonoBehaviour
    {
        private float timer;
        private float showTime;
        private bool activeTimer;
        private string message;
        private Text uiText;
    
        void Start()
        {
            uiText = GetComponent<Text>();
        }
    
        void Update()
        {
            if (activeTimer)
            {
                timer += Time.deltaTime;
                if (timer > showTime)
                {
                    activeTimer = false;
                    uiText.text = "";
                }
            }
        }
    
        void startTimer()
        {
            timer = 0.0f;
            showTime = 3.0f;
            uiText.text = message;
            activeTimer = true;
        }
    
        void showText(string m)
        {
            message = m;
            startTimer();
        }
    }
