public class Car 
{
    // This is the 'delegate type'
    // ‘Delegate type’ is what is responsible for defining the method such as its signature 
    // which include return type and parameters
    // In this ‘Delegate type’ named:'CarEngineHandler', the return type is 'void' and there are no parameters
    public delegate void CarEngineHandler();
    //this is the ‘Delegate instance’
    //‘Delegate instance’ is responsible for holding the reference to the actual methods 
    //that adheres to the delegate type. 
    //Delegate instance can be used to then ‘invoke’ that method whenever needed. 
    public CarEngineHandler listOfHandlers;
    public void Accelerate(int delta)
    {
       if (delta > 80) 
            //this is where you use the 'Delegate instance' to ‘invoke’ the methods 
            // You can also you use: listOfHandlers.Invoke(); 
            // which is same as calling 'listOfHandlers();'
            // When delegate instance is invoked, all its actions in its invocation list are executed in order
            //In this example it will first dispaly: "Sorry, this car is dead..."
            // then display: "Calling, emergency..."
          listOfHandlers();    // not checking null for simplicity 
    }
}
class Program
{
    static void Main(string[] args)
    {
            Car myCar = new Car(); 
            //This is where you add to the 'delegate instance', the 'target method's' that matches delegate signature
            //A 'delegate instance' can contain more than one action. This list of actions is called the “invocation list”.
            //You can also add multiple methods to invocation list like this: myCar.listOfHandlers += CallWhenExploded;  
            myCar.listOfHandlers = new Car.CarEngineHandler(CallWhenExploded);
            // For example you can add another target method like this:
            myCar.listOfHandlers += CallEmergencyService; 
            // you get details about the 'target methods' attached to the “invocation list” like this:
            var listOfTargets = myCar.listOfHandlers.GetInvocationList();
            Console.WriteLine(listOfTargets[0].Method.Name); 
            myCar.Accelerate(120);
    }
    static void CallWhenExploded() 
    {
       Console.WriteLine("Sorry, this car is dead..."); 
    }
    static void CallEmergencyService() 
    {
       Console.WriteLine("Calling, emergency..."); 
    }
}
