    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class RandomQuestionGentrator : MonoBehaviour {
    
        List<int> All_possible_values_of_b = new List<int>();  //List to store all possible value that b can hold;
    
    	void Start ()
        {
            int minRange = 1;
            int MaxRange = 11;
    
            for (int  i = minRange; i <= MaxRange; i++)    //inserting all possible value of b in list
            {
                All_possible_values_of_b.Add(i);
            }
    	}
    	
    	void Update ()
        {
    		if(Input.GetKeyDown("a"))           //call GenrateNewRandomQuestion when user press correect answer button;
            {
                GenrateNewRandomQuestion();
            }
    	}
    
        void GenrateNewRandomQuestion()
        {
            int a = Random.RandomRange(1, 11);      //a can remain random;
    
            if(All_possible_values_of_b.Count <= 0)     // changing range when all values of b has been used;
            {
                setnewrange();
            }
    
            int UsedValueOf_b_InList = Random.Range(0, All_possible_values_of_b.Count);    //accessing remaining values of b in list;
    
            int b = All_possible_values_of_b[UsedValueOf_b_InList];         //b = some value in list;
    
            All_possible_values_of_b.RemoveAt(UsedValueOf_b_InList);     //dropping the value of b that is used 
    
            Debug.Log(a + "x" + b);
        }
    
        void setnewrange()          //setting new range
        {
            int minRange = 12;
            int MaxRange = 30;
            for (int i = minRange; i <= MaxRange; i++)
            {
                All_possible_values_of_b.Add(i);
            }
        }
    }
