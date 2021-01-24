using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
public class ControllerPointers : MonoBehaviour
{
   private IMixedRealityInputSystem inputSystem = null;
   /// <summary>
   /// The active instance of the input system.
   /// </summary>
   protected IMixedRealityInputSystem InputSystem
   {
       get
       {
           if (inputSystem == null)
           {
               MixedRealityServiceRegistry.TryGetService<IMixedRealityInputSystem>(out inputSystem);
           }
           return inputSystem;
       }
   }
   // Update is called once per frame
   void Update()
   {
       // Log something every 60 frames.
       if (Time.frameCount % 60 == 0)
       {
           foreach (IMixedRealityController controller in InputSystem.DetectedControllers)
           {
               if (controller.Visualizer?.GameObjectProxy != null)
               {
                   Debug.Log("Visualizer Game Object: " + controller.Visualizer.GameObjectProxy);
               }
               else
               {
                   Debug.Log("Controller has no visualizer!");
               }
               foreach (IMixedRealityPointer pointer in controller.InputSource.Pointers)
               {
                   if (pointer is MonoBehaviour)
                   {
                       var monoBehavior = pointer as MonoBehaviour;
                       Debug.Log("Found pointer game object: " + (monoBehavior.gameObject));
                   }
               }
           }
       }
   }
}
Lastly, you could also always grab the position/rotation/velocity properties off of the pointer interfaces themselves (i.e. in the code above, use the pointer position: https://microsoft.github.io/MixedRealityToolkit-Unity/api/Microsoft.MixedReality.Toolkit.Input.IMixedRealityPointer.html#Microsoft_MixedReality_Toolkit_Input_IMixedRealityPointer_Position)
