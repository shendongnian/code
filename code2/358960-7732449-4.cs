    public class FuncManipulator<T>
    {
        private Func<T> _method;
                
        public void SetExecutableMethod(Func<T> methodParam)
        {
            _method = methodParam;
        }
        //you must pass the actual array; we are creating a closure reference that will live
        //as long as the delegate
        public void SetMethodParams(object[] param)
        {
            _param = param;
        } 
        
        public T ExecuteMethod(params object[] passedParam)
        {
           //We have to re-initialize _param based on passedParam
           //instead of simply reassigning the reference, because the lambda
           //requires we don't change the reference.
           for(int i=0; i<_param.Length; i++)
              _param[i] = passedParam.Length <= i ? null : passedParam[i];
           //notice we don't pass _param; the lambda already knows about it
           //via the reference set up when declaring the lambda.
           return _method(); 
        }
    
    }
    ...
       
    public void InitAndTest()
    {
        //this is an "external closure" we must keep in memory
        object[] param = new object[2];
        SetExecutableMethod( () => _service.SomeMethod1(param[0], param[1]) );
        //We do so by passing the reference to our object
        SetMethodParams(param);
        //now, don't ever reassign the entire array.
        //the ExecuteMethod function will replace indices without redefining the array.
        T result1 = ExecuteMethod("Test1", "Test2");
        T result2 = ExecuteMethod("Test3", "Test4");
        T result3 = ExecuteMethod("Test6", "Test5");
    }
