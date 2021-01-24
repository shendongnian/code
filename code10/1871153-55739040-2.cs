    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class Slid : MonoBehaviour
    {
        Slider slide;
        bool sliderSelect = false;
    
    // Start is called before the first frame update
        void Start()
        {
            slide = GetComponent<Slider>();
        }
        public void SliderSelected()
        {
            sliderSelect = true;
        }
        public void SliderDeselect()
        {
            sliderSelect = false;
        }
        public void Update()
        {
            float currentMinute = System.DateTime.Now.Minute + (System.DateTime.Now.Hour * 60);
            float barPercentage = currentMinute / 1440;
            if (!sliderSelect)
            {
                slide.value = barPercentage;
            }
        }
    }
