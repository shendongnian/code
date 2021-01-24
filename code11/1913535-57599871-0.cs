    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    
    public class ClickExample : MonoBehaviour {
        public Button btn;
        void Start()
        {
            if (PlayerPrefs.HasKey("buttonState")) // if the button was saved in memory
            {
               if(PlayerPrefs.GetInt("buttonState") == 0) //if the value is 0
                   btn.interactable = false; // make button disabled
            }
            else
            {
                 PlayerPrefs.SetInt("buttonState",1); // saving in memory that button is on
            }
            
        }
    
        public void buttonCliked(){
            btn.interactable = false; // making the button disabled
            PlayerPrefs.SetInt("buttonState",0); //saving in memory that button is off 
        }
    
    }
