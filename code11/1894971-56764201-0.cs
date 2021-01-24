	void Main()
	{
		var myJson = @"
		{
			""employee"": [{
		        ""fullname"": {
		            ""firstname"": ""abcd"",
		            ""lastname"": ""defg""
		        },
		        ""project"": [{
		                ""projectname"":""abcd_1"",
		                ""datejoined"": ""2019-06-18T01:29:38.6013262+00:00"",
		                ""projectmanager"": ""abcdM1"",
		            }, {
						""projectname"":""abcd_2"",
		                ""datejoined"": ""2018-06-18T01:29:38.6013262+00:00"",
		                ""projectmanager"": ""abcdM2"",
		            }, {
						""projectname"":""abcd_3"",
		                ""datejoined"": ""2017-06-18T01:29:38.6013262+00:00"",
		                ""projectmanager"": ""abcdM3"",
		            }
		        ]
		    },{
				""fullname"": {
					""firstname"": ""abcd"",
		            ""lastname"": ""defg""		
				},
		        ""project"": [{
		                ""projectname"":""abcd_1"",
		                ""datejoined"": ""2019-06-18T01:29:38.6013262+00:00"",
		                ""projectmanager"": ""abcdM1"",
		            }, {
						""projectname"":""abcd_2"",
		                ""datejoined"": ""2018-06-18T01:29:38.6013262+00:00"",
		                ""projectmanager"": ""abcdM2"",
		            }, {
						""projectname"":""abcd_3"",
		                ""datejoined"": ""2017-06-18T01:29:38.6013262+00:00"",
		                ""projectmanager"": ""abcdM3"",
		            }
		        ]
		      }
		    ]
		}";
				
				
		var myObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Employee>(myJson);
		var myTrimmedJson = Newtonsoft.Json.JsonConvert.SerializeObject(myObject);
		Console.WriteLine(myTrimmedJson);
	}
	
	public class Fullname
	{
		public String firstname { get; set; }
		//public String lastname { get; set; }
	}
	
	public class Project
	{
		public String projectname { get; set; }
		//public String datejoined { get; set; }
		//public String projectmanager { get; set; }
	}
	
	public class Person
	{
		public Fullname fullname { get; set; }
		public List<Project> project { get; set; }
	}
	
	public class Employee
	{
		public List<Person> employee { get; set; }
	}
