 csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
					
public class Program
{
	public class Record{
		public string Name {get;set;}
		public string Value {get;set;}
	}
	
	public static void Main()
	{
		var regex = new Regex(@"(?<name>((?!-)[\w]+[ ]?)*)(?>(?>[ \t]+)?(?<name>((?!-)[\w]+[ ]?)+)?)+(?:\r\n|\r|\n)(?>(?<splitters>(-+))(?>[ \t]+)?)+(?:\r\n|\r|\n)(?<value>((?!-)[\w]+[ ]?)*)(?>(?>[ \t]+)?(?<value>((?!-)[\w]+[ ]?)+)?)+", RegexOptions.Compiled);
		var testingValue =
@"EMAIL STARTING IN APRIL
Marketing ID                                     Local Number
-------------------                              ----------------------
GR332230                                         0000232323
Dispatch Code                                    Logic code
-----------------                                -------------------
GX3472                                           1
Destination ID                                   Destination details
-----------------                                -------------------
3411144";
		var matches = regex.Matches(testingValue);
		var rows = (
			from match in matches.OfType<Match>()
			let row = (
				from grp in match.Groups.OfType<Group>()
				select new {grp.Name, Captures = grp.Captures.OfType<Capture>().ToList()}
			).ToDictionary(item=>item.Name, item=>item.Captures.OfType<Capture>().ToList())
			let names = row.ContainsKey("name")? row["name"] : null
			let splitters = row.ContainsKey("splitters")? row["splitters"] : null
			let values = row.ContainsKey("value")? row["value"] : null
			where names != null && splitters != null &&
				names.Count == splitters.Count &&
				(values==null || values.Count <= splitters.Count)
			select new {Names = names, Values = values}
			);
		
		var records = new List<Record>();
		foreach(var row in rows)
		{
			for(int i=0; i< row.Names.Count; i++)
			{
				records.Add(new Record{Name=row.Names[i].Value, Value=i < row.Values.Count ? row.Values[i].Value : ""});
			}
		}
		
		foreach(var record in records)
		{
			Console.WriteLine(record.Name + " = " + record.Value);
		}
	}
}
output:
Marketing ID  = GR332230 
Local Number = 0000232323
Dispatch Code  = GX3472 
Logic code = 1
Destination ID  = 3411144
Destination details =
Please note that this also works for this kind of message:
EMAIL STARTING IN APRIL
Marketing ID                                     Local Number
-------------------                              ----------------------
GR332230                                         0000232323
Dispatch Code                                    Logic code
-----------------                                -------------------
GX3472                                           1
Destination ID                                   Destination details
-----------------                                -------------------
                                                 3411144
output:
Marketing ID  = GR332230 
Local Number = 0000232323
Dispatch Code  = GX3472 
Logic code = 1
Destination ID  = 
Destination details = 3411144
Or this:
EMAIL STARTING IN APRIL
Marketing ID                                     Local Number
-------------------                              ----------------------
Dispatch Code                                    Logic code
-----------------                                -------------------
GX3472                                           1
Destination ID                                   Destination details
-----------------                                -------------------
                                                 3411144               
output:
Marketing ID  = 
Local Number = 
Dispatch Code  = GX3472 
Logic code = 1
Destination ID  = 
Destination details = 3411144
