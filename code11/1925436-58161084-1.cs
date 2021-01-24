    static class ExpressionHelpers {
        public static Func<string, string, TUserResult> CreateUserDelegate<TUserResult>() {
            var type = typeof(TUserResult);
            var username = type.GetProperty("username", BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
            var password = type.GetProperty("password", BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
            //string username =>
            var usernameSource = Expression.Parameter(typeof(string), "username");
            //string password =>
            var passwordSource = Expression.Parameter(typeof(string), "password");
            // new TUser();
            var user = Expression.New(type);
            // new TUser() { UserName = username, Password = password }
            var body = Expression.MemberInit(user, bindings: new[] {
                Expression.Bind(username, usernameSource),
                Expression.Bind(password, passwordSource)
            });
            // (string username, string password) => new TUser() { UserName = username, Password = password }
            var expression = Expression.Lambda<Func<string, string, TUserResult>>(body, usernameSource, passwordSource);
            return expression.Compile();
        }
        public static Func<TService, string, Task<string>> CreateEncryptValueDelegate<TService>() {
            // (TService service, string name) => service.EncryptValueAsync(name);
            var type = typeof(TService);
            // TService service =>
            var service = Expression.Parameter(type, "service");
            // string name =>
            var name = Expression.Parameter(typeof(string), "name");
            // service.EncryptValueAsync(name)
            var body = Expression.Call(service, type.GetMethod("EncryptValueAsync"), name);
            // (TService service, string name) => service.EncryptValueAsync(name);
            var expression = Expression.Lambda<Func<TService, string, Task<string>>>(body, service, name);
            return expression.Compile();
        }
        public static Func<TClient, TUser, Task<TResponse>> CreateClaimSearchDelegate<TClient, TUser, TResponse>() {
            var type = typeof(TClient);
            // TClient client =>
            var client = Expression.Parameter(type, "client");
            // TUser user =>
            var user = Expression.Parameter(typeof(TUser), "user");
            var method = type.GetMethod("ClaimSearchAsync");
            var enumtype = method.GetParameters()[4].ParameterType; //statuscode
            var enumDefault = Activator.CreateInstance(enumtype);
            var arguments = new Expression[] {
                user,
                Expression.Constant(string.Empty), //ssn
                Expression.Constant(string.Empty), //lastname
                Expression.Constant(12345), //claimnumber
                Expression.Constant(enumDefault), //statuscode
                Expression.Constant(string.Empty)//assignto
            };
            // client.ClaimSearchAsync(user, ssn: "", lastname: "", claimnumber: 12345, statuscode: default(enum), assignedto: "");
            var body = Expression.Call(client, method, arguments);
            // (TClient client, TUser user) => client.ClaimSearchAsync(user,....);
            var expression = Expression.Lambda<Func<TClient, TUser, Task<TResponse>>>(body, client, user);
            return expression.Compile();
        }
    }
