    public class car { 
 
      private int _carId; 
      private string _carName; 
      private int speed=0;
 
      public Car(int carId) {
        this._carId=carId;
      }
      public int CarId {
        get { return this._carId; } 
      }
      public string  CarName {
        get { return this._carName; }
        set { this._carName=value; }
      }
      public int Speed {
        get { return this._speed; }
      }
      public void Accelerate() {
        if (this._speed<91) this._speed++;
      }
    } 
    public class MsSqlCarRepository : ICarRepository {    
    
      public MsSqlCarRepository(SqlConnection conn) {.....}
    
      IEnumerable<car> GetCarcollection(){ ................ }
    
    }    
    public class XmlCarRepository : ICarRepository {    
    
      public XmlCarRepository(string FileName) {.....}
    
      IEnumerable<car> GetCarcollection(){ ................ }
    
    }    
