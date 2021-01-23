    struct type_var {
    #if INT_ONLY
      int m_value;
    #else
      long m_value;
    #endif
    
      public type_var(int i) {
        m_value = i;
      }
      
    #if INT_ONLY
      public type_var(long l) {
        m_value = l;
      }
    #endif
    
      public static operator type_var(int i) {
        return new type_var(i);
      }
    
    #if INT_ONLY
      public static operator type_var(long i) {
        return new type_var(i);
      }
    #endif
    // Etc ...    
    }
