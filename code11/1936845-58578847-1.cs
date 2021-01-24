foreach(var i in phraseSources)
{
   i.JishoExists = "";
   i.CommonWord = "";
   i.JishoWanikani = null;
   i.JishoJlpt = null;
}
----
`ToList().ForEach` can lead to unexpected results. Consider the following example. 
public class XClass {public string A {get; set;}}
public struct XStruct {public string A {get; set;}}
public static void Main(string[] args)
{
    var array1 = new []{new XClass{A="One"}, new XClass{A="Two"}};
    var array2 = new []{new XStruct{A="One"}, new XStruct{A="Two"}};
    array1.ToList().ForEach( x => x.A = "XXX");
    array2.ToList().ForEach( x => x.A = "XXX");
    Console.WriteLine(array2[0].A); // Ooops: it's still "One"
}
