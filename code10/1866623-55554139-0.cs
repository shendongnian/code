    public int Handle<T>(CreateCodeModel obj) where T : CodeModel
    {
        //Create code here...
        return 7;
    }
    // this static variable preserves the generic MethodInfo, so we don't have
    // keep discovering it with reflection
    private static MethodInfo _methodInfoForHandle;
    // The generic MethodInfo only needs to be discovered the first time this runs
    private MethodInfo MethodInfoForHandle
    {
        get
        {
            return _methodInfoForHandle ?? (_methodInfoForHandle = GetMethodInfoForHandleMethod());
        }
    }
    private MethodInfo GetMethodInfoForHandleMethod()
    {
        Func<CreateCodeModel, int> handleFunc = Handle<CodeModel>;
        return handleFunc.Method.GetGenericMethodDefinition();
    }
    //codeType is selected by user.
    public int Handle(CreateCodeModel obj, Type codeType)
    {
        MethodInfo genericMethod = MethodInfoForHandle.MakeGenericMethod(new Type[] { codeType });
        return (int)genericMethod.Invoke(this, new object[] { obj });
    }
    public class CreateCodeModel { }
    public class CodeModel { }
    public class JavascriptCodeModel : CodeModel { }
