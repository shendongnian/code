C#
void Main()
{
	List<int> A = new List<int>() {1,2}; //ids list
	List<myObject> B = new List<myObject>()
	{
		new myObject{Id=1,state="Run"},
		new myObject{Id=2,state="Idle"},
		new myObject{Id=3,state="Idle"},
	};
	
	var expectedResult = from t1 in B
		join t2 in A on t1.Id equals t2
		where t1.state == "Idle"
		select t1;
}
// Define other methods and classes here
class myObject
{
	public int Id { get; set; }
	public string state { get; set; }
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/IW28w.png
