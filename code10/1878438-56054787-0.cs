services.AddAuthentication(o =>
{
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.IncludeErrorDetails = true;
    o.RequireHttpsMetadata = false;
    o.TokenValidationParameters = jwtHandler.Parameters;
    o.Events = new JwtBearerEvents()
    {
        OnAuthenticationFailed = c =>
        {
            c.NoResult();
            c.Response.StatusCode = 401;
            c.Response.ContentType = "text/plain";
            return c.Response.WriteAsync(c.Exception.ToString());
        }
    };
});
I have sent you a [pull-request][2].
  [1]: https://github.com/a-molaei/RSA_Core2/blob/4f8321a7e890a1c1f29c4258b0d4ef5ceb0a3db7/RSA_Core2/Startup.cs#L63
  [2]: https://github.com/a-molaei/RSA_Core2/pull/1
