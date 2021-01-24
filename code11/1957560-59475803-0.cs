[NoZeroIntakeOnFood]
public class ModelClass
{
    public string food{ get; set; }
    public string intake { get; set; }
}
Here is a sample model-level validation (rather than attribute-level):
public class NoZeroIntakeOnFoodAttribute : ValidationAttribute {
    public NoZeroIntakeOnFoodAttribute() 
    {
        ErrorMessage = "Intake cannot be zero, when food has value";
    }
    public override bool IsValid(object value) 
    {
        ModelClass model = value as ModelClass;
        if (model?.food != null ) 
        {
           // the intake needs to be more than zero
           if( Convert.ToInt32(model.intake) > 0)
               return true;
           else return false;
        }
        
        return true;
    }
}
Don't forget to put the `NoZeroIntakeOnFood` on your model class.
Of course, grab the above code and tweak it to your needs.
Hope this helped. :)
--
Here, we assumed you're on MVC 5 .Net Framework. If you're using Asp.Net Core MVC, have a look on the [docs][1] for better adaptation.
  [1]: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1#custom-attributes
