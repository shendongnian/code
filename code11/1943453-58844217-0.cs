abstract class Base
{
	public abstract void Init()
}
class SubA : Base
{
	public SubA(int a)
	{
		this.Init();
	}
	public override void Init()
	{
		// do stuff
	}
	public void Init(int a)
	{
		//do stuff with int
	}
}
if you want to call init without overriding it, then the abstract base class needs to implement it like this
abstract class Base
{
	public void Init()
	{
		//do stuff in the implementation by the abstract class
	}
}
class SubA : Base
{
	public SubA(int a)
	{
		this.Init();
	}
	public void Init(int a)
	{
		//do stuff with int
	}
}
It seems like what you want is to be able to re-init any subclass of `Base`, with the option to for the sub classes to perform custom initialization. 
If you want them to re-init to their original state, you could store their original state in the instance, and restore is with Init() that is overridden. 
class Foo : Base
{
	private int _iOrig;
	private string _sOrig;
	
	public int i { get; set; }
	public string s { get; set; }
	
	public Foo(int i, string s)
	{
		this.i = i;
		this._iOrig = i;
		this.s = s;
		this._sOrig = s;
	}
	public override void Init()
	{
		this.i = _iOrig;
		this.s = _sOrig;
	}
}
You might even consider using an interface if everything is going to to be abstract.
If instead you want to reinitialize them using outside data, you could loop through them and check what type they are, and call their own `Init` method, this means that `Base` doesn't need to have a `abstract Init()`, and the sub classes can implement whatever they want. (this doesn't seem to be what you want though).
This could be done in the loop using a cast check.
private void InitAll(IEnumerable<Base> collection)
{	
	
	foreach(Base b in collection)
	{
		var sa = b as SubA;
		if(sa != null)
		{
			sa.Init(getInt());
			continue;
		}
		var sb = b as SubB;
		if (sb != null)
		{
			sb.Init(getString());
			continue;
		}
	}
}
