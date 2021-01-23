    public static object GetProperty(object target, string name)
    {
    	var site = System.Runtime.CompilerServices.CallSite<Func<System.Runtime.CompilerServices.CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, name, target.GetType(), new[]{Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo.Create(0,null)}));
    	return site.Target(site, target);
    }
