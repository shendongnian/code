csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeperAI : MonoBehaviour
{
    public LeperTrigger lepertriggerinstance;
    void Start()
    {
        lepertriggerinstance = GameObject.FindWithTag("enemy").GetComponent<LeperTrigger>();
    }
    void Update()
    {
        if(lepertriggerinstance.IsOnLeper == true)
        {
            Debug.Log("Leper jump");
        }
    }
}
