void Main()
{
    test tt = new test();
    GetInstance(tt.GetType().ToString());
}
public object GetInstance(string strFullyQualifiedName)
{
    var t = Type.GetType(strFullyQualifiedName).Dump();
	var res = Activator.CreateInstance(t);
	return  res;
}
public class test{
	public int id {get;set;}
	public test(){}
}
