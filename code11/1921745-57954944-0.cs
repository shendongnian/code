public interface IReturnableAs {
  public String ReturnAs { get; }
}
public interface IReturnableAsImage<T>
{
  public String ReturnAs =>"image";
  protected String ImageResolution { get; set; }    
  public T ReturnAsImage(String imageResolution = "large") 
  {
    ImageResolution = imageResolution;
    return (T)this;
  }
}
public interface IReturnableAsJson<T> {
  public String ReturnAs =>"json";
  protected Boolean IsPretty { get; set; }
  public T ReturnAsJson(Boolean isPretty = false) {
    IsPretty = isPretty;
    return (T)this;
  }
}
public class Foo : IReturnableAsImage<Foo>, IReturnableAsJson<Foo> ,IReturnableAs
{
    string IReturnableAs.ReturnAs =>"image;json";
    String IReturnableAsImage<Foo>.ImageResolution { get; set; }="3";
    Boolean IReturnableAsJson<Foo>.IsPretty { get; set; }=false;
}
The following code :
void Main()
{
  var foo=new Foo();
  Console.WriteLine(((IReturnableAs)foo).ReturnAs);
  Console.WriteLine(((IReturnableAsImage<Foo>)foo).ReturnAs);
  Console.WriteLine(((IReturnableAsJson<Foo>)foo).ReturnAs); 
}
Prints:
image;json
image
json
I removed the `ReturnAs` setters since the valid value will always be the same for the same interface. 
If you want to create a new class that generates JPGs, eg `FooJpg`, you can override the default implementation of `IReturnableAsImage<T>`, eg : 
public class FooJpg : IReturnableAsImage<FooJpg>, IReturnableAsJson<FooJpg> ,IReturnableAs
{
    string IReturnableAs.ReturnAs =>"jpg;json";
    String IReturnableAsImage<FooJpg>.ImageResolution { get; set; }="3";
    Boolean IReturnableAsJson<FooJpg>.IsPretty { get; set; }=false;
    
    String IReturnableAsImage<FooJpg>.ReturnAs => "jpg";
    
}
**Same result no matter the interface**
If you want `Foo.ReturnAs` to always return the same value, eg `"image;json"`, you can add a default `IReturnAs` implementation for single use cases, and override the method for multiple uses :
public interface IReturnableAs {
  public String ReturnAs { get; }
}
public interface IReturnableAsImage<T>:IReturnableAs
{
  String IReturnableAs.ReturnAs =>"image";
  
  protected String ImageResolution { get; set; }    
  public T ReturnAsImage(String imageResolution = "large") 
  {    
    ImageResolution = imageResolution;
    return (T)this;
  }
}
public interface IReturnableAsJson<T>:IReturnableAs { 
  String IReturnableAs.ReturnAs =>"json";
    
  protected Boolean IsPretty { get; set; }
  public T ReturnAsJson(Boolean isPretty = false) {
    //ReturnAs="json";
    IsPretty = isPretty;
    return (T)this;
  }
}
In this case the `IReturnableAsImage`, `IReturnableAsJson` interfaces provide an implementation. For this class : 
public class Foo : IReturnableAsImage<Foo>
{
    String IReturnableAsImage<Foo>.ImageResolution { get; set; }="3";
}
The following code will print `image`:
void Main()
{
  var foo=new Foo();
  Console.WriteLine(((IReturnableAs)foo).ReturnAs);
  Console.WriteLine(((IReturnableAsImage<Foo>)foo).ReturnAs);
}
For a class that uses both interfaces, an explicit `IReturnableAs` implementation is needed: 
public class FooMulti : IReturnableAsImage<FooMulti>, IReturnableAsJson<FooMulti> 
{
    String IReturnableAs.ReturnAs =>"image;json";
    String IReturnableAsImage<FooMulti>.ImageResolution { get; set; }="3";
    Boolean IReturnableAsJson<FooMulti>.IsPretty { get; set; }=false;
}
In this case all calls will return `image;json` : 
void Main()
{
  var foo=new FooMulti();
  Console.WriteLine(((IReturnableAs)foo).ReturnAs);
  Console.WriteLine(((IReturnableAsImage<FooMulti>)foo).ReturnAs);
  Console.WriteLine(((IReturnableAsJson<FooMulti>)foo).ReturnAs); 
}
image;json
image;json
image;json
