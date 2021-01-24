    public class SpecialThingyFilter : IActionFilter
    {
        public bool AllowMultiple { get; }
        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            var commandsWithSpecialThingy = actionContext.ActionArguments
                .Where(x => x.Value != null && x.Value.GetType().GetInterfaces().Contains(typeof(IHasSpecialThingy)))
                .Select(x => x.Value).ToList();
            if (!commandsWithSpecialThingy.Any())
            {
                return await continuation.Invoke();
            }
            foreach (var dto in commandsWithSpecialThingy)
            {
                //Do your magic stuffs here
                ((IUserRightsDependentCommand)dto).specialThingy = // Something special
            }
            return await continuation.Invoke();
        }
    }
