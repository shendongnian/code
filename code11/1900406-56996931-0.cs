    public class BaseService : IBaseService
    {
        // ...
        private readonly IActionContextAccessor _actionContextAccessor;
        public BaseService(
            // ...
            IActionContextAccessor actionContextAccessor
        ) {
            // ...
            _actionContextAccessor = actionContextAccessor;
        }
        async Task<bool> IBaseService.SaveContext() {
            var actionContext = _actionContextAccessor.ActionContext;
            if (actionContext.ModelState.IsValid) {
                // ...
            }
            else {
                return false;
            }
        }
    }
