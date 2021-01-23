    type
      MyClass = class(IReusable)
      private
        property Reused : IReusable := new MyReusedClass(); readonly;
          implements public IReusable;
      end;
