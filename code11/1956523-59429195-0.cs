public class ValidCar
{
    public CarModel Model {get; set;}
    public CarEntity Entity {get; set;}
}
First you assemble all the data you need into a `new ValidCar`, and then you can use FluentValidation rules on this new model to ensure it's actually valid.
One benefit to this approach is you can have your business logic methods require a `ValidCar` as a parameter instead of just a `CarModel`. This makes it very difficult to accidentally forget to validate the car in some code path, and it prepackages up data that's likely to be useful to much of the business-level logic that you plan to use.
