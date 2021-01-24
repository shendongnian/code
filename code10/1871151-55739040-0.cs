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
            var currentMinute = System.DateTime.Now.Minute + (System.DateTime.Now.Hour * 60);
            var barPercentage = currentMinute / 1440;
            Debug.Log(sliderSelect);
            if (!sliderSelect)
            {
                slide.value = barPercentage;
            }
        }
    }
