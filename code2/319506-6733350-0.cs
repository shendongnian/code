    using ImpromptuInterface;
    using ImpromptuInterface.Dynamic;
    public interface IMyInterface{
       string Prop1 { get;  }
        long Prop2 { get; }
        Guid Prop3 { get; }
        bool Meth1(int x);
    }
...
    //Dynamic Expando object
    dynamic tNew = Build<ExpandoObject>.NewObject(
             Prop1: "Test",
             Prop2: 42L,
             Prop3: Guid.NewGuid(),
             Meth1: Return<bool>.Arguments<int>(it => it > 5)
    );
   
    IMyInterface tActsLike = Impromptu.ActLike<IMyInterface>(tNew);
