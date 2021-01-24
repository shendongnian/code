    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class CountdownTimer : MonoBehaviour
    {
        public SkinnedMeshSpawn SkinnedMeshSpawn;
    
        void Start()
        { 
            StartCoroutine(FunctionCaller(3f,3f));
        }
    
        IEnumerator FunctionCaller(float pause1, float pause2)
        {
            SkinnedMeshSpawn.GetComponent<SkinnedMeshSpawn>().MoveCubes();
     
            yield return new WaitForSeconds(pause1);
    
            SkinnedMeshSpawn.GetComponent<SkinnedMeshSpawn>().LerpSine();
    
            yield return new WaitForSeconds(pause2);
    
            // Do whatever after pause 2
        }
    }
