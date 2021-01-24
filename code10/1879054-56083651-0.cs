    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class SwitchScript : MonoBehaviour
    {
        public GameObject avatar1, avatar2;
        int wichAvatarIsOn;
        void Start()
        {
    		if(PlayerPrefs.HasKey("wichAvatarIsOn"))
    		{
    			wichAvatarIsOn = PlayerPrefs.GetInt("wichAvatarIsOn");
    		}
    		else
    		{
    			wichAvatarIsOn = 1;//Default to an avatarID you want as default
    		}
    		SwitchAvatar(wichAvatarIsOn);
        }
    
        public void SwitchAvatar(int avatarID)
        {
            switch (avatarID)
            {
                case 1:
                    wichAvatarIsOn = 2;
                    avatar1.gameObject.SetActive(false);
                    avatar2.gameObject.SetActive(true);
                    break;
                case 2:
                    wichAvatarIsOn =  1;
                    avatar1.gameObject.SetActive(true);
                    avatar2.gameObject.SetActive(false);
                    break;
    			default:
    				//Set a default avatar incase out of range and add a debug message
    				Debug.Log("Avatar ID out of range: " + avatarID);
    				wichAvatarIsOn = 2;
                    avatar1.gameObject.SetActive(false);
                    avatar2.gameObject.SetActive(true);
    				break;
            }
        }
    }
