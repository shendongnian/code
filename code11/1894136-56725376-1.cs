public static class ClaimsIdentitExtensions
{
    public static string GetReferencia(this ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(c => c.Type == "Referencia")?.Value;
    }
}
In your controller you could do:
    User.GetReferencia();
In the view you could use:
    @User.GetReferencia()
If you need this is a Model, you could pass the User to the model (e.g. contructor)
