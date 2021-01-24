        public class CustomAuthorize : IAuthorizationFilter         
        {
                private readonly int _input;
                public CustomAuthorize(int input)
                {
                    _input = input;
                }
                public void OnAuthorization(AuthorizationFilterContext context)
                {
                    //custom validation rule
                    if (_input == 1)
                    {
                        context.Result = new ForbidResult();
                    }
                }
        }
