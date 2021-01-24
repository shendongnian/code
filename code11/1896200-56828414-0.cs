using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class B : MonoBehaviour
{
    public void Initialise()
    {
        //Code you run on Start()    
    }
}
2-) Reference B obj in A obj, use bObj.Initialise after are ready to initialise it: 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class A : MonoBehaviour
{
    public B bObj;
    // Start is called before the first frame update
    void Start()
    {
        //Things to do in Start()
        //...
        //...
        //...
        bObj.Initialise();
    }
}
Lastly, if you want your Update function run whenever you want, I usually prefer to use something as a flag. So here's my second version of class B for controlling update() behavior: 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class B : MonoBehaviour
{
    public bool canUpdate;
    public void Initialise()
    {
        //Code you run on Start()
        canUpdate = true;    
    }
    private void Update()
    {
        if (canUpdate)
        {
            //do the stuff
        }
    }
}
