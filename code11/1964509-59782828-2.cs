using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			var List1 = new List<Person>{
			new  Person{
				id  =  1,
				fnName  = "bla"
			},  new  Person{
				id  =  2,
				fnName  = "bla2"
			}
		};
			var List2 = new List<Payment>{
			new  Payment{
				paymentId  =  1,
				paymentType  = "type1",
				paymentPersonIds  =  new string[]{"1"},
				PersonDetails = Enumerable.Empty<Person>(),
			},
			new  Payment{
				paymentId  =  2,
				paymentType  = "type2",
				paymentPersonIds  =  new string[]{"1","2"},
				PersonDetails = Enumerable.Empty<Person>(),
			}
		};
			
			List2.ForEach(l2 => {
                var personList = new List<Person>();
				l2.paymentPersonIds.ToList().ForEach(id => {
					var matched = List1.FirstOrDefault(l1 => l1.id.ToString().Contains(id));
					if (matched != null)
					{
						personList.Add(matched);
					}
				});
				l2.PersonDetails = personList as IEnumerable<Person>;
			});
			Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(List2));
		}
    }
	public class Person
	{
		public int id;
		public string fnName;
		public string lnName;
	}
	public class Payment
	{
		public int paymentId;
		public string paymentType;
		public IEnumerable<string> paymentPersonIds;
		public IEnumerable<Person> PersonDetails;
	}
}
