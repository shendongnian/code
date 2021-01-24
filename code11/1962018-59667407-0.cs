    virtual method should not do anything,it's just a contract,what your goal is a bad ideal.
    
    you should do it like this:
    
    public class animal
    {
       public virtual void eat()
       {
          //don't do anything
       }
    }
    
    public class dog:animal
    {
       public override void eat()
       {
         //eat Meat
       }
    }
    
    public class sheep:animal
    {
       public override void eat()
       {
         //eat grass
       }
    }
