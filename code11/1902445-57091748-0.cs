c#
using System.Linq;
public static string MyTest(string format, params object[] args) {
    var newarr = new object[] { "arg0" };
    newarr.Concat(args);
    var result = string.Format(format, newarr);
    return result;
}
