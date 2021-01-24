 csharp
public static IRuleBuilderOptions<T, TProperty> When<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Func<T, TProperty, bool> predicate, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators)
{
    return rule.Configure(config => {
        config.ApplyCondition(ctx => predicate((T)ctx.Instance, (TProperty)ctx.PropertyValue), applyConditionTo);
    });
}
## Test
 csharp
public class Class1
    {
        [Fact]
        public void AAAA()
        {
            var x = new A { Value = "" };
            var y = new A { Value = "100" };
            var av = new AValidator();
            av.ValidateAndThrow(x);
            Should.Throw<ShouldAssertException>(() => av.ValidateAndThrow(y));
        }
    }
    class A
    {
        public string Value { get; set; }
    }
    class AValidator : AbstractValidator<A>
    {
        public AValidator()
        {
            RuleFor(a => a.Value.ToString())
                .MustHasLengthBetween(1, 10);
        }
    }
    public static class AExtensions
    {
        public static IRuleBuilderOptions<T, string> MustHasLengthBetween<T>(this IRuleBuilder<T, string> rule, int min, int max)
        {
            return rule
                .Length(min, max).WithMessage("AGAGA")
                .When((t, p) => !string.IsNullOrEmpty(p));
        }
        public static IRuleBuilderOptions<T, TProperty> When<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Func<T, TProperty, bool> predicate, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators)
        {
            return rule.Configure(config => {
                config.ApplyCondition(ctx => predicate((T)ctx.Instance, (TProperty)ctx.PropertyValue), applyConditionTo);
            });
        }
    }
