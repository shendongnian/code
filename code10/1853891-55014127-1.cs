    public class MyGameManager
    {
        public void Start()
        {
            // However you reference the controllers, do it here.
            myRightVRController.OnPickedUp += SomeFunc1;
            myRightVRcontroller.OnLetGo += SomeFunc2;
            myLeftVRController.OnPickedUp += SomeFunc3;
            myLeftVRController.OnLetGo += SomeFunc4;
            // The rest of your initialization...
        }
    }
