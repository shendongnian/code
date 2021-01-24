using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class UpdateImage : MonoBehaviour {
    public Button button;
    public Sprite noImg;
    public Sprite nug;
    public Text score;
    public int score_int = 0;
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(UpdateImageTask);
    }
    void UpdateImageTask()
    {
        //button = GetComponent<Button>();
        if(button.GetComponent<Image>().sprite == nug)
        {
            score_int = System.Int32.Parse(score.text);
            score_int++;
            score.text = score_int.ToString();
        }
        button.GetComponent<Image>().sprite = noImg;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
