    void TheMethod<TException>(Func<Exception,TException> factory) {
      ...
      catch (Exception ex) {
        var wrapped = factory(ex);
        ...
      }
    }
      
