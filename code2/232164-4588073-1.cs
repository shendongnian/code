    public interface InterfaceA {
      bool Enable { get; set; }
      void Reset();
    }
    public class Object1 : InterfaceA {
      public bool Enable { get; set; }
      public void Reset(){
        Enable = false;
      }
    }
    public class Object2 : InterfaceA {
      public bool Enable { get; set; }
      public void Reset(){
        Enable = false;
      }
    }
    void Manipulate(InterfaceA pObj){
      pObj.Enable = true;
      pObj.Reset();
    }
    void Main(){
      Manipulate(obj1);
      Manipulate(obj2);
    }
