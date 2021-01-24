    public class Foo
    {
    public async Task<string> Method1()
    {
        //run a task
        return result;
    }
    public async void Method2(string result)
    {
        //do some work
        //do some work
        //do some work
        //wait for method1
        //do something with result
    }
    }
    await Task.Run(()=>
    {
    Foo foo = new Foo();
    var result = foo.Method1();
    foo.Method2(result);
    });
    
   
