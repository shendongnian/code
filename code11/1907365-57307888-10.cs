    namespace Airport
    {
        public class Airport
        {
            //this will hold the planes. I choose Stack<> rather than string[] because arrays are not push/pop'able in c# and youre using your javasscript array like a stack (LIFO)
            private Stack<string> _planes = new Stack<string>();
            public Airport() //you don't need to pass anything to your airport when you construct it
            {
            }
    
            //In c# method declarations look like:
            //<AccessModifier> <ReturnType> <MethodName>(<ArgumentList>)
            //Methods cannot be marked as "void string" as a return type - you must choose either void (if it returns nothing) or string(if it returns a string). 
            //If it returns something else one day, like a Plane object, it should be marked as returning Plane. 
            //Your JS Land method returns nothing so I declare void
            public void Land(string plane){
                _planes.Push(plane);
            }
            public string Takeoff() //this returns a plane, so we declare the return type as string
            {
                return _planes.Pop(); //need to handle errors if the planes list is empty btw       
            }
        }
    }
