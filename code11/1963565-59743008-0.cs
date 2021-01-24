using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Main : MonoBehaviour
{
    Side sideOfSomething;
    public GameObject Something;
    void Start()
    {
        sideOfSomething = Something.GetComponent<Side>();
        Debug.Log(sideOfSomething.isDead);
    }
    // Update is called once per frame
    void Update()
    {
       Debug.Log(sideOfSomething.isDead);
    }
} 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Side : MonoBehaviour
{
    public bool isDead;
    void Awake() // called prior to any Start
    {
        isDead = false;
    }
  
    // Empty magic methods waste cycles
}
