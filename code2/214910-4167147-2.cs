    public interface ISpeaks
    {
        string Speak();
    }
    
    public class Dog : Mammal, ISpeaks
    {
        public string Speak() { return "Woof!"; }
    }
    
    public class Person : Mammal, ISpeaks
    {
        public string Speak() { return "Hi!"; } 
    }
    //Notice Telephone has a different abstract class
    public class Telephone : Appliance, ISpeaks
    {
       public Person P { get; set; }
       public Telephone(Person p)
       {
         P = p;
       }
       public string Speak() { return P.Speak(); } 
    }
    
    
    [Test]
    public void Test_Objects_Can_Speak()
    {
        List<ISpeaks> thingsThatCanSpeak = new List<ISpeaks>();
        //We can add anything that implements the interface to the list
        thingsThatCanSpeak.Add(new Dog());
        thingsThatCanSpeak.Add(new Person());
        thingsThatCanSpeak.Add(new Telephone(new Person()));
       
       foreach(var thing in thingsThatCanSpeak)
       {
           //We know at compile time that everything in the collection can speak
           Console.WriteLine(thing.Speak());
       }
    }
