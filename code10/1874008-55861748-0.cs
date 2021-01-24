public class RoomList<T> where T : class
{
    private DailyList current;
    private DailyList head;
    public void Add(DailyList newItem)
    {
		if(current != null)
			current.next = newItem;
		current = newItem;
	    if(head == null) 
			head = current;
    }
	
	public IEnumerable<DailyList> GetAllNodes() 
	{
		DailyList current  = head;
		List<DailyList> lst = new List<DailyList>();
		while (current != null) 
		{
			lst.Add(current);
			current = current.next;
		}
		return lst;
	}
    public class DailyList
    {
        public DailyList next;
        private DailyListElement head;
        private DailyListElement current;
        public void Add(DailyListElement newItem)
        {
			if(current != null)
				current.next = newItem;
			current = newItem;
			if(head == null) 
				head = current;
        }
		
		public IEnumerable<DailyListElement> GetAllNodes()
		{
			DailyListElement current  = head;
			List<DailyListElement> lst = new List<DailyListElement>();
			while (current != null) 
			{
				lst.Add(current);
				current = current.next;
			}
			return lst;
		}
        public class DailyListElement
        {
            public T data;
            public DailyListElement next;
        }
    }
}
The client code:
using System;
using System.Collections.Generic;
public class Program
{
	public static void Main()
	{
		var lst =new RoomList<string>();
		
		var upperNode = new RoomList<string>.DailyList();
		var element = new RoomList<string>.DailyList.DailyListElement();
		element.data = "first";
		upperNode.Add(element);
		element = new RoomList<string>.DailyList.DailyListElement();
		element.data = "second";
		upperNode.Add(element);
		lst.Add(upperNode);
		
		upperNode = new RoomList<string>.DailyList();
		
		element = new RoomList<string>.DailyList.DailyListElement();
		element.data = "third";
		upperNode.Add(element);
		element = new RoomList<string>.DailyList.DailyListElement();
		element.data = "fourth";
		upperNode.Add(element);
		
		lst.Add(upperNode);
		
		foreach(var item in lst.GetAllNodes())
		{
			foreach(var child in item.GetAllNodes())
			{
				Console.WriteLine(child.data);
			}
		}
	}
}
