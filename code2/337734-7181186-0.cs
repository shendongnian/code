    class Bar:IDisposable
    {
    	void Dispose()
    	{
    	//do some logic
    	}
    }
    class BarCollection:List<Bar>,IDisposable
    {
    	void Dispose()
    	{
    		foreach(Bar bar in this){
    			bar.Dispose();
    		}
    	}
    }
    
    class Foo
    {
        BarCollection Children;
    
        void Dispose()
        {
            CurrentDispatcher.BeginInvoke(Children.Dispose, ApplicationIdle, null);
        }
    }
