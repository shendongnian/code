    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class HMDCheck : MonoBehaviour
    {
    public GameObject target, scripts, LocalAvatar;
 
    private void Update()
    {
        if (!OVRManager.hasVrFocus || !OVRManager.isHmdPresent || !OVRManager.hasInputFocus)
        {
            //target.SetActive(false);
            scripts.SetActive(false);
            LocalAvatar.SetActive(false);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            //target.SetActive(true);
            scripts.SetActive(true);
            LocalAvatar.SetActive(true);
            Time.timeScale = 1f;
            AudioListener.pause = false;
         }
     }
     }
