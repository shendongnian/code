    public class Foo{
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
            var intermediaryResult = await Method1();
            //do something with result
        }
    }
    
    Foo foo = new Foo();
    await foo.Method2(result);
