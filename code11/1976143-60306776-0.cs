    public class FooMiddleware
    {
        public FooMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        private readonly RequestDelegate _next;
        public async Task InvokeAsync(HttpContext context, ILifetimeScope scope)
        {
            scope.Resolve<Foo>(); 
            await this._next(context);
        }
    }
