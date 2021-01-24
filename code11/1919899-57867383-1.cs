using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Very important
public class Wood : MonoBehaviour
{
    public int totalWood = 0;
    public Text totalWoodText; //attach your text component here
	void Update()
	{
        totalWoodText.text = totalWood.ToString(); //just one line command
		if(Input.GetKeyDown(KeyCode.A))
		{
			addOneWood();
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			addFiveWood();
		}
		if(Input.GetKeyDown(KeyCode.Y))
		{
			delOneWood();
		}
		if(Input.GetKeyDown(KeyCode.X))
		{
			delFiveWood();
		}
	
	}
    public void addOneWood()
    {
        totalWood += 1;
        Debug.Log("Amount added!");
        print(totalWood);
    }
    public void addFiveWood()
    {
        totalWood += 5;
        Debug.Log("Amount added!");
        print(totalWood);
    }
    public void delOneWood()
    {
        totalWood -= 1;
        Debug.Log("Amount Removed!");
        print(totalWood);
    }
    public void delFiveWood()
    {
        totalWood -= 5;
        Debug.Log("Amount Removed!");
        print(totalWood);
    }
}
