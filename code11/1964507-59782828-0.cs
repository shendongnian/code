using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		
		var  List1  =  new  List<Person>{
			new  Person{  
				id  =  1,
				fnName  = "bla"
			},	new  Person{  
				id  =  2,
				fnName  = "bla2"
			}
		};
		
		var  List2  =  new  List<Payment>{
			new  Payment{  
				paymentId  =  1,
				paymentType  = "type1"
			},	new  Payment{  
				paymentId  =  2,
				paymentType  = "type2"
			}
		};
		
		List2.ForEach(l2 => {
			l2.paymentPersonIds.ToList().ForEach(id  => {
				var matched =  List1.FirstOrDefault(l1 => l1.id.ToString().Contains(id));
				if(matched !=  null){
					l2.PersonDetails.Append(matched);
				}
			});
		});
	}
}
public class Person
{
   public  int id;
   public  string fnName;
   public  string lnName;
}
public class Payment
{
   public  int paymentId;
   public  string paymentType;
   public  IEnumerable<string> paymentPersonIds;
   public  IEnumerable<Person> PersonDetails;
}
