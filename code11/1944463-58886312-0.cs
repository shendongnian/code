using System.Diagnostics.CodeAnalysis;
public static class Validate
{
   public static void NotNull([NotNull]object? value, string parameterName, string? field = null)
   {
     if (value == null) throw new ArgumentNullException(parameterName + (field == null ? string.Empty : "." + field));
   }
}
after that, this won't give warnings anymore:
int Func(string? param)
{
    Validate.NotNull(param, nameof(param));
    return param.Length;
}
