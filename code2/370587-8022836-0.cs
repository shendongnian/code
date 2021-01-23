       public virtual void MyVirtual(){ 
          Console.writeLine("Base virtual");
       }
    
       public void MyNonVirtual(){
          Console.WriteLine("Base non virtual");
       }
    }
    
    public class Derived : BaseClass {
    
       public virtual void MyVirtual(){ 
          Console.writeLine("Derived virtual");
       }
    
       public new void MyNonVirtual(){
          Console.WriteLine("Derived non virtual");
       }
    }
    
    BaseClass b = new BaseClass();
    Derived d = new Derived();
    BaseClasse dAsb = d;
    
    b.MyVirtual(); //prints Base virtual
    b.MyNonVirtual(); //print Base non virtual
    
    d.MyVirtual(); //prints Derived virtual
    d.MyNonVirtual(); //print Derived non virtual
    
    dAsb.MyVirtual(); //prints Derived virtual
    dAsb.MyNonVirtual(); //print Base non virtual
