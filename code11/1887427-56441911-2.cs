    public static class RegistrationExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> 
            Trace<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registration)
        {
            return registration.OnPreparing(e => { Console.WriteLine($"{e.Component.Activator.LimitType.Name}.preparing"); })
                               .OnActivating(e => { Console.WriteLine($"{e.Component.Activator.LimitType.Name}.activating"); })
                               .OnActivated(e => { Console.WriteLine($"{e.Component.Activator.LimitType.Name}.activated"); })
                               .OnRelease(e => { Console.WriteLine($"{e.GetType().Name}.release"); }); ;
        }
    }
