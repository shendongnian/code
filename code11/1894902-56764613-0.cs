      using System.Collections;
      using System.Collections.Generic;
      using UnityEngine;
      using UnityEngine.SceneManagement;
      using UnityEngine.UI;
      public class VoltaMenu : MonoBehaviour
     {
    // Start is called before the first frame update
    void Start()
    {
    }
     
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale ==0){
				Time.timeScale = 1;
				hidePaused();
			}
		}
     }
    // Update is called once per frame
    public void BackToGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
     void showPaused()
     { //Write code to show dailogue here
     }
     void hidePaused()
     { //Write code to hide dailogue i.e Pause menu
     } 
    }
