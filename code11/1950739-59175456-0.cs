using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour {
	int Health;
	int Day;
	int Food;
	int Money;
	// Use this for initialization
	void Start () {
		Health = 100;
		Food = 100;
		Day = 0;
		Money = 0;
		Debug.Log(Health);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
