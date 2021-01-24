c.SupportedSubmitMethods(new Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod[] { }
Entire code sample - (Add inside configure method)
 app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/test/swagger.json", "test API");
                c.SupportedSubmitMethods(new Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod[] { });
            });
This is worked because, we have used SubmitMethod enum which have following values inside that - 
    public enum SubmitMethod
    {
        Get = 0,
        Put = 1,
        Post = 2,
        Delete = 3,
        Options = 4,
        Head = 5,
        Patch = 6,
        Trace = 7
    }
