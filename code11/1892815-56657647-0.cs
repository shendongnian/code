cs
public class Dto
{
	public readonly long? PhoneNumber;
}
And then you are trying to force AutoMapper to do this:
cs
var dto = new Dto();
dto.PhoneNumber = 123; // <== ERROR! A readonly field cannot be assigned to.
AutoMapper cannot write to readonly fields or properties. In matter of fact you neither. Either turn your field into a property with `protected` or `private` setter:
cs
public class Dto
{
	public long? PhoneNumber { get; private set; }
}
or make it a regular field by removing the `readonly` keyword:
cs
public class Dto
{
	public long? PhoneNumber;
}
# 2) Custom value resolving
### ASP.NET MVC
Use a [`ValueResolver`](http://docs.automapper.org/en/stable/Custom-value-resolvers.html):
cs
public class StringPhoneNumberResolver : IValueResolver<Dto, ViewModel, string>
{
    private readonly IPhoneNumberService _phoneNumberService;
    public StringPhoneNumberResolver()
    {
        _phoneNumberService = DependencyResolver.Current.GetService<IPhoneNumberService>();
    }
    public string Resolve(Dto source, ViewModel destination, string destMember, ResolutionContext context)
    {
        return _phoneNumberService.GetFormattedPhoneNumber(source.PhoneNumber);
    }
}
You should know that generally it is an anti-pattern to have service injection in a DTO or `IValueResolver`. AutoMapper should be dumb and all kind of injections and so on should be handled elsewhere. That being said, here is the AutoMapper configuration:
cs
Mapper.Initialize(cfg =>
{
    cfg.CreateMap<Dto, ViewModel>()
        .ForMember(viewModel => viewModel.PhoneNumber, options =>
            options.MapFrom<StringPhoneNumberResolver>());
});
If you want to reverse the process of `long` ==> `string` to `string` ==> `long` simply add another value resolver:
cs
public class LongPhoneNumberResolver : IValueResolver<ViewModel, Dto, long?>
{
    private readonly IPhoneNumberService _phoneNumberService;
    public LongPhoneNumberResolver()
    {
        _phoneNumberService = DependencyResolver.Current.GetService<IPhoneNumberService>();
    }
    public long? Resolve(ViewModel source, Dto destination, long? destMember, ResolutionContext context)
    {
        return _phoneNumberService.GetLongPhoneNumber(source.PhoneNumber);
    }
}
### .NET Core
If you would operate in .NET Core environment, which fully supports `IServiceCollection` integration, you should add this AutoMapper configuration:
cs
serviceCollection.AddAutoMapper(config =>
{
    config.CreateMap<Dto, ViewModel>()
        .ForMember(viewModel => viewModel.PhoneNumber, options =>
            options.MapFrom<StringPhoneNumberResolver>());
}, typeof(Startup));
and then have `IPhoneNumberServce` automagically injected into value resolver:
cs
public StringPhoneNumberResolver(IPhoneNumberService phoneNumberService)
{
    _phoneNumberService = phoneNumberService;
}
For dependency injection I used [automapper.extensions.microsoft.dependencyinjection](https://www.nuget.org/packages/automapper.extensions.microsoft.dependencyinjection/) package.
