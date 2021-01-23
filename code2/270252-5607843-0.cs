    public interface ITypeArgs{
       IList<Type> TypeArguments{get;}
    }
...
    
    var typeArgs = binder.ActLike<ITypeArgs>().TypeArguments;
