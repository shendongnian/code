class SharedClass{
  public int commonVar{get;set;} //not threadsafe
}
Every class that needs to have access to it it must get a reference to it through constructor.
class ConsumerOne{
   SharedClass shared; 
   public ConsumerOne(SharedClass shared)
   { 
      this.shared = shared;
   }
   public IncreaseThat(){ 
      shared.commonVar++;
   }
}
class ConsumerTwo{
   SharedClass shared; 
   public ConsumerTwo(SharedClass shared)
   { 
      this.shared = shared;
   }
   public DecreaseThat(){ 
      shared.commonVar--;
   }
}
And at your Program main you make the binding.
main(){
   var shared = new SharedClass();
   var one = new ConsumerOne(shared);
   var two = new ConsumerTwo(shared);
   one.IncreaseThat();
   Console.WriteLine(shared);
   two.DecreaseThat();
   Console.WriteLine(shared);
}
That way you can tell what your classes are using and you will skip global variables.
