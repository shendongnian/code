     private void MyGenericMethod<T>(T arg)
            {
                if(arg.GetType().IsValueType)
                {
                    //T is value type
                }
            }
