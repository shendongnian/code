    interface class I
    {
      property bool IsOk
      {
        bool get();
      }
    };
    
    public ref class A abstract : I
    {
    private:
      virtual property bool IsFine
      {
        bool get() sealed = I::IsOk::get
        {
          return false;
        }
      }
    };
