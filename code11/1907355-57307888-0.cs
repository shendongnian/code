    namespace Airport
    {
        public class Airport
        {
            //this will hold the planes. I choose Stack<> rather than string[] because arrays are not push/pop'able in c# and youre using your javasscript array like a stack (LIFO)
            private Stack<string> _planes = new Stack<string>();
            public Airport() //you don't need to pass anything to your airport when you construct it
            {
            }
    
            public void Land(string plane) //you're using string for planes. Methods are either void or string as a return type. This method returns nothing so I declare void
            {
                _planes.Push(plane);
            }
            public string Takeoff() //this returns a plane, so we declare the return type as string
            {
                return _planes.Pop(); //need to handle errors if the planes list is empty btw       
            }
        }
    }
