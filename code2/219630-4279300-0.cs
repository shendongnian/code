    int? _writeOnceField;
    
    private int? WriteOnce
    {
       set
       {
          if (!_writeOnceFiled.HasValue)
          {
            writeOnceFiled = value;
          }
          else
          {
            // Throw exception
          }
       }
    }
