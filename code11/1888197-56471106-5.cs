    [CompilerGenerated]
    private sealed class <GetEnumerator>d__1 : IEnumerator<object>, IDisposable, IEnumerator
    {
      private int <>1__state;
    
      private object <>2__current;
    
      public C <>4__this;
    
      object IEnumerator<object>.Current
      {
          [DebuggerHidden]
          get
          {
              return <>2__current;
          }
      }
    
      object IEnumerator.Current
      {
          [DebuggerHidden]
          get
          {
              return <>2__current;
          }
      }
    
      [DebuggerHidden]
      public <GetEnumerator>d__1(int <>1__state)
      {
          this.<>1__state = <>1__state;
      }
    
      [DebuggerHidden]
      void IDisposable.Dispose()
      {
      }
    
      private bool MoveNext()
      {
          switch (<>1__state)
          {
              default:
                  return false;
              case 0:
                  <>1__state = -1;
                  <>2__current = <>4__this.data[0];
                  <>1__state = 1;
                  return true;
              case 1:
                  <>1__state = -1;
                  <>2__current = <>4__this.data[1];
                  <>1__state = 2;
                  return true;
              case 2:
                  <>1__state = -1;
                  <>2__current = <>4__this.data[2];
                  <>1__state = 3;
                  return true;
              case 3:
                  <>1__state = -1;
                  <>2__current = <>4__this.data[3];
                  <>1__state = 4;
                  return true;
              case 4:
                  <>1__state = -1;
                  <>2__current = <>4__this.data[4];
                  <>1__state = 5;
                  return true;
              case 5:
                  <>1__state = -1;
                  return false;
          }
      }
    
      bool IEnumerator.MoveNext()
      {
          //ILSpy generated this explicit interface implementation from .override directive in MoveNext
          return this.MoveNext();
      }
    
      [DebuggerHidden]
      void IEnumerator.Reset()
      {
          throw new NotSupportedException();
      }
    }
