    public class A
    {
      int _Num1, _Num2;
    
      int Num1 {get {return _Num1;}; }
      int Num2 {get {return _Nun2;}; }
    
      protected void SetNum (int pWhich, int pV)
      {
          if ( pWhich == 1 ) {_Num1 = pV; return;}
          _Num2 = pV;
      } 
    } 
