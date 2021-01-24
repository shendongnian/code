    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class DeathCounter : MonoBehavior
    {
        public Text DeathCount;
        public void SetText(String text)
        {
            DeathCount.text = "Death Count: " + text;
        }
    }
