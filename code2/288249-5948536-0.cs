     class SqlMethods
     {
          string _target; // probably want to use a StringBuilder instead
          public SqlMethods(string target)
          {
              _target = target;
          }
          SqlMethods Left(int n)
          {
              _target = ...; // implementation of Left()
              return this;
          } 
          public override string ToString() {return _target;}
     }
