public void OnGUI()
 {
     if(Event.current.type == EventType.ScrollWheel)
         // do stuff with  Event.current.delta
         Debug.Log(Event.current.delta);
 }
The `OnGui` documentation can be found here: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnGUI.html
using UnityEngine;
using System.Collections;
public class ExampleClass : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
        {
            print("You clicked the button!");
        }
    }
}
> OnGUI is called for rendering and handling GUI events.
>
> This means that your OnGUI implementation might be called several times per frame (one call per event). For more information on GUI events see the Event reference. If the MonoBehaviour's enabled property is set to false, OnGUI() will not be called.
