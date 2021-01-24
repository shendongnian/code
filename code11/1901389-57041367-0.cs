    public class Demo
    {
    	private _wsClient = new DemoWrapper();
    		
        public static void Run()
        {   // Exemple of consuming the method 
            var input = new BarQuery { Bar_Label = "user input", Bar_Ig = 42 };
    
            BarResponse result = Bar(input);
        }
    	
    	public FooResponse Foo(FooQuery foo) =>
    		Execute(foo, query => _wsClient.Foo(query));
    	
    	public BarResponse Bar(BarQuery bar) =>
    		Execute(bar, query => _wsClient.Bar(query));
    	
    	public FooBarResponse FooBar(FooBarQuery fooBar) =>
    		Execute(fooBar, query => _wsClient.FooBar(query));
    	
        private static TResponse Execute<TQuery ,TResponse>(
            TQuery param, Func<TQuery, TResponse> getResponse) 
    	{
            //Get temp line where Query type match Param Type.
            var result = default(TResponse);
            try
            {
                result = getResponse(query);
            }
            catch (Exception e)
            {
                // SimpleTrace();
                // SoapEnvelopeInterceptorTrace();               
                // TimeWatch_PerformanceIEndpointBehaviorTrace();
            }
    
            return result;
        }
    }
