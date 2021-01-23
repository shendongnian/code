     public void Process(){
            //...get MethodInfo and so on
            List<object> myReturnValue = new List<object>(((IList)methodInfo.Invoke(this, new object[]{param})).ToArray());
            // here comes no Exception!
        }
