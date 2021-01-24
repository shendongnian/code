cs
var x = new List<string> { "123" }
var y = x[0].Length; // x[0] - returns String, which is generic
However if you want to have "generic wrapper" it is better to extract interface. To return to your code:
cs
interface IFoo 
{
     string Zoo { get; set; }
}
public class Roo<TInput,TOutput> where TInput: IFoo {
    public string QueueJob(TInput param)
    {
        Foo<TInput> x = new Foo<TInput>{ ..., Boo = param};
        
        return x.Boo.Zoo; // we require TInput to implement IFoo. It means that any input value have Zoo property, therefore you can use it
    }
}
Why do we need this interface (or base class):
