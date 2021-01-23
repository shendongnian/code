            Func<int> a = () => { throw new NotImplementedException(); };
            try
            {
                //int value = lazyCount.Value;
                a();
            }
            catch (NotImplementedException e)
            {
            }
