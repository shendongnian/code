	using System;
    using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	public class Random_Number : MonoBehaviour
	{
	  public List <int> ListofNumbers = new List<int>(); // List of the numbers being called
	  public List <string> DeadNumbers = new List<string>(); // List of numbers that have been called
	  public Text text_to_be_Printed; // Text Element
	  private int numberSelected;
	  private string numberSelected_str;
	  public string DeadNumbers_str;
	  void Start() {
		text_to_be_Printed = GetComponent<Text>();
		for(int i = 1; i <= 90; i++){
			ListofNumbers.Add(i); // Makes a list of all the numbers 
		  }
	  }
	  void Update()
	  {
		if (Input.GetKeyDown("space")){ // If space is pressed -text
		  numberSelected = ListofNumbers[Random.Range (0, ListofNumbers.Count)]; // Get a random number text
		  numberSelected_str = numberSelected.ToString();
		  text_to_be_Printed.text = numberSelected_str;
		  DeadNumbers.Add(numberSelected_str);
		  ListofNumbers.Remove(numberSelected);
		  Debug.Log(String.Join(", ", DeadNumbers));
		  // DeadNumbers_str = String.Join(",", DeadNumbers);
		  // Debug.Log(DeadNumbers_str);
		}
	  }
	}
