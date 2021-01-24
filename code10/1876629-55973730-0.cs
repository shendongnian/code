    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    public class Score : MonoBehaviour
    {
        public Text pointsdisplay;
        int points = 0;
        void Start()
        {
            pointsdisplay.text = points.ToString();
        } 
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "enemy(Clone)")
            {
                points = points + 1;
                pointsdisplay.text = points.ToString();
            }
        }
     }
