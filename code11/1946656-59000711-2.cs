    public class Globals
    {
        public int[] Args;
    }
    ...
    // create script that sum all input arguments
    var script = CSharpScript.Create(@"var result = 0;
    foreach (var item in Args)
    {
        result += item;
    }
    return result; ", globalsType: typeof(Globals));
    // run it at twice on the user values that were received before
    // also you can reuse an array, but anyway
    var res1 = script.RunAsync(new Globals { Args = new[] { 5, 6, 7 } }).Result.ReturnValue;
    var res2 = script.RunAsync(new Globals { Args = new[] { 7, 8, 9, 10} }).Result.ReturnValue;
