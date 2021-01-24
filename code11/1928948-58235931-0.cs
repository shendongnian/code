    public class MyControllerClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new MyController
                {
                  Id = 1,
                  // ...
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
2. Modify your Theory
    [Theory]
    [ClassData(typeof(MyControllerClassData))]
    public async Task Get_Return_Something(MyController sut)
    {
        var result1 = await sut.Get(""); // when placing "sut" as param, I get: cannot convert from MyController to string. 
        var result2 = await sut.Get(null); // same applies here..
        result1.ShouldBeOfType(typeof(OkObjectResult));
        result2.ShouldBeOfType(typeof(BadRequestObjectResult));
    }
## Possibility 2 ##
1. Create the MyController class in the constructor and store it on a private property
2. Change the parameters to string and the `objectResult` that you want
3. Use always the same MyController, use the string to do the `Get()` and validate it against the `objectResult` expected.
This solution seems a lit bit cleaner, as you have one test for each situation.
