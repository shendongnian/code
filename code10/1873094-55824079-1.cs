    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class Load : MonoBehaviour
    {
	Text userNameText;
      void Start()
      {
		userNameText = GetComponent<Text>();
		userNameText.text = PlayerPrefs.GetString("userName");
        
    }
    }
