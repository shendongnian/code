public abstract class MehodResponseBase {
    public abstract void  DoSpecialThing();
    public abstract string responseText;
}
public class Method100Response201 : MehodResponseBase
{
    public override responseText = "Method100Response201";
    public string R1_01 { get; set; }
    public override void DoSpecialThing()
    { Console.WriteLine ("Something Blue..}"); }
}
public class Method100Response404 : MehodResponseBase
{
    public override responseText = "Method100Response404";
    public string R2_01 { get; set; }
    public override void DoSpecialThing()
    { Console.WriteLine ("Something Old..}"); }
}
public class Method110Response200 : MehodResponseBase
{
    public override responseText = "Method110Response200";
    public string R3_01 { get; set; }
    public override void DoSpecialThing()
    { Console.WriteLine ("Something New..}"); }
}
Then we can extract their creation into a factory
pubic class MethodResponseFactory() 
{
    public static MehodResponseBase Make(int method, int response)
    {
        if (method == 100) 
        {
            if(response == 201) 
            {
                return new Method100Response201();
            }
            if(response == 404) 
            {
                return new Method100Response404();
            }
        }
        if (method == 110) 
        {
            if (response == 200) 
            {
                return new Method110Response200();
            }
        }
        throw new MethodResponseCreationException($"Cannot create for mothod: {method} and response: {response}")
    }
}
So your response model is refactored to
public static string ResponseModel(int method, int response)
{
        try 
        {
            return MethodResponseFactory.Make(method, response).returnClass;
        }
        catch (MethodResponseCreationException ex)
        {
            return string.Empty;
        }
}
So, as you can see, all the delegation for creating the object is now in the factory. And `resonseModel` class simply calls the factory to build a class based on the `method` and `response`.
  [1]: https://refactoring.guru/design-patterns/creational-patterns
