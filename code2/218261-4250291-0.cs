    public class Base {
      private readonly object m_Data; //immutable data, as per JaredPar suggestion that base class shouldn't be able to change it
      publlic Base(object data) {
        m_Data = data;
      }
    
      
      protected virtual object GetData() {return m_Data;}
    
      public Object DataSource {get {return GetData();}} 
    }
    
    public class Derived<T> : Base {
      private T m_Data;
    
      public Derived():base(null){}
      protected override object GetData() {return m_Data;}
    
      protected new T Data {return m_Data;}
    }
