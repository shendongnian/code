    public interface IDisplayable
    {
        void Display();
        string GetInfo();
    }
   
    public class Human : IDisplayable
    {
        public void Display() { return String.Format("The person is {0}", 
            GetInfo());
       
        // Rest of Implementation
    }
 
    public class Animal : IDisplayable
    {
        public void Display() { return String.Format("The animal is {0}", 
            GetInfo());
       
        // Rest of Implementation
    }
    public class Building : IDisplayable
    {
        public void Display() { return String.Format("The building is {0}", 
            GetInfo());
       
        // Rest of Implementation
    }
    public class Machine : IDisplayable
    {
        public void Display() { return String.Format("The machine is {0}", 
            GetInfo());
       
        // Rest of Implementation
    }
