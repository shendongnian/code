    public int LargeMethod()
        {    
            var t1 = new Task<int>.Factory.StartNew(SmallMethodA);
            return SmallMethodB() + t1.Result;
        }
