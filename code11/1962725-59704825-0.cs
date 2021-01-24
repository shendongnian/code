    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class GenerateRandom : MonoBehaviour
    {
        private List<int> lastNumbers;
        void Start()
        {
            lastNumbers = new List<int>();
            //Use a seed to get the same numbers every time.
            //https://docs.unity3d.com/ScriptReference/Random-state.html
            //Random.InitState(932903292);
    
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("Random number: " + GenerateRandomNumber());
            }
        }
    
        public int GenerateRandomNumber()
        {
            //The highest number you want here. The lower number is inclusive, higher one exclusive.
            int rand = Random.Range(0, 10);
    
            //Regenerate while the lastNumbers contains random.
            while (lastNumbers.Contains(rand))
            {
                rand = Random.Range(0, 10);
            }
    
            //Store it.
            AddNumberToList(rand);
    
            //Give back the number we generated.
            return rand;
        }
    
        void AddNumberToList(int number)
        {
            if (lastNumbers.Count > 3)
            {
                lastNumbers.RemoveAt(lastNumbers.Count - 1);
            }
            lastNumbers.Insert(0, number);
            Debug.Log("Last numbers: ");
            for (int i = 0; i < lastNumbers.Count; i++)
            {
                Debug.Log($"Index ({i}): {lastNumbers[i]}");
            }
        }
    }
