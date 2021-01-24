 csharp
public static IRuleBuilderOptions<T, TProperty> When<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Func<T, TProperty, bool> predicate, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators)
{
    return rule.Configure(config => {
        config.ApplyCondition(ctx => predicate((T)ctx.Instance, (TProperty)ctx.PropertyValue), applyConditionTo);
    });
}
## Test
 csharp
public class UnitTest1
{
    [Fact]
    public void Should_validate_length ()
    {
        var ok1 = new Model { MyProperty = null };
        var ok2 = new Model { MyProperty = "" };
        var ok3 = new Model { MyProperty = "55555" };
        var fail = new Model { MyProperty = "1" };
        var v = new ModelValidator ();
        v.ValidateAndThrow (ok1);
        v.ValidateAndThrow (ok2);
        v.ValidateAndThrow (ok3);
        Should.Throw<ValidationException> (() => v.ValidateAndThrow (fail));
    }
    public class Model
    {
        public string MyProperty { get; set; }
    }
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator ()
        {
            RuleFor (x => x.MyProperty)
                .MustHaveLengthBetween (5, 10);
        }
    }
}
public static class Extensions
{
    public static IRuleBuilderOptions<T, string> MustHaveLengthBetween<T> (this IRuleBuilder<T, string> rule, int min, int max)
    {
        return rule
            .Length (min, max).WithMessage ("AGAGA")
            .When ((model, prop) => !string.IsNullOrEmpty (prop));
    }
    /// <summary>
    /// Predicate builder which makes the validated property available
    /// </summary>
    /// <param name="IRuleBuilderOptions<T"></param>
    /// <param name="rule"></param>
    /// <param name="predicate"></param>
    /// <param name="applyConditionTo"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, TProperty> When<T, TProperty> (this IRuleBuilderOptions<T, TProperty> rule, Func<T, TProperty, bool> predicate, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators)
    {
        return rule.Configure (config =>
        {
            config.ApplyCondition (ctx => predicate ((T) ctx.Instance, (TProperty) ctx.PropertyValue), applyConditionTo);
        });
    }
}
