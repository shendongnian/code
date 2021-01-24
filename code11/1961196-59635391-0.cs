C#
public Result GrantDo(Action<Result> action, MyContext? ctx = null, MyAction? act = null) =>
    IsAllowed(context ?? this.Context, act ?? this.Action) 
        ? action 
        : PermissionDenied();
