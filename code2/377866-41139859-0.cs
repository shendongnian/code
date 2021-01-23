    using System;
    using System.IO;
    enum TYPE_OPERATION
    {
        Design,
        Work
    }
    //Abstract Factory
    abstract class AbstractFactory
    {
        public static AbstractFactory PrepareOperation(TYPE_OPERATION type_operation)
        {
            switch (type_operation)
            {
                case TYPE_OPERATION.Design:
                    return new DesignTeam();
                case TYPE_OPERATION.Work:
                    return new WorkTeam();
                default:
                    throw new NotImplementedException();
            }
        }
        public abstract void PerformOperation();
    }
        
    class DesignTeam : AbstractFactory
    {
        public override void PerformOperation()
        {
            Designers m = new Designers();
            m.Designing();
        }
    }
        
    class WorkTeam : AbstractFactory
    {
        public override void PerformOperation()
        {
            Workers k = new Workers();
            k.Working();
        }
    }
    
    // The concrete class
    class Designers
    {
        public void Designing()
        {
            Console.WriteLine("The Design Team has completed its work!");
        }
    }
    // The concrete class
    class Workers 
    {
        public  void Working()
        {
            Console.WriteLine("The Work Team has finished its work!");
        }
    }
    public class Client
    {   
        public static void Main(String[] args)
        {
            AbstractFactory factory = AbstractFactory.PrepareOperation(TYPE_OPERATION.Design);
            factory.PerformOperation();
            factory = AbstractFactory.PrepareOperation(TYPE_OPERATION.Work);
            factory.PerformOperation();
            Console.ReadLine();
        }
     }
    /* output:
     The Design Team has completed its work!
     The Work Team has finished its work!
    */
