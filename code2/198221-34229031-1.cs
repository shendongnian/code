    var ty = typeof(IAmGeneric<>);
    var numTyParams = ty.GenericTypeArguments.Length;
    var mi = ... do something with ty to get generic def for SoAmI<> ...
    var parameters = new[] { typeof(int), typeof(string) };
    var output = MethodBase.GetMethodFromHandle(mi.MethodHandle, ty.MakeGenericType(parameters.Take(numTyParams).ToArray()).TypeHandle).MakeGenericMethod(parameters.Skip(numTyParams).ToArray());
