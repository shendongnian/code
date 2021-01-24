C#
interface ISkill
{
    void apply();
}
class Base : ISkill
{
    protected string name { get; set; }
	protected Base(string name)
	{
		this.name = name;
	}
	public void apply()
	{
		show();
		Console.WriteLine(name + " apply");
	}
	
    private void show()
    {
        Console.WriteLine("show:"+name);
    }
}
class Skill1 : Base
{
    public Skill1(): base("skill1"){}    
}
class Skill2 : Base
{
    public Skill2(): base("skill2"){}    
}
