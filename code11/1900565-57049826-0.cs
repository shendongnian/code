			public class Student
			{
				public string sid { get; set; }
			}
			public class Strength
			{
				public int Str { get; set; }
				public List<Student> stu { get; set; }
			}
			public class Profile
			{
				public int name { get; set; }
				public ICollection<Strength> strength { get; set; }
			}
			public class Program
			{
				public static void Main(string[] args)
				{
					
			 var ipData = new[]
				{
					new { ColC = 1, ColB = 101, ColA = "val1" },
					new { ColC = 1, ColB = 101, ColA = "val2" },
					new { ColC = 1, ColB = 102, ColA = "val3" },
					new { ColC = 1, ColB = 102, ColA = "val4" }
				};
					var prof = new Profile();
					var stren = new List<Strength>();
					
					var dColB = ipData.Select(x => x.ColB).Distinct();
					foreach(var newval in dColB)
					{
						Console.WriteLine(newval);
						var colval = ipData.Where(x => x.ColB == newval);
						var stud = new List<Student>();
						foreach(var nval in colval)
						{
							var stuval = new Student { sid = nval.ColA };
							stud.Add(stuval);                   
						}
						var strval = new Strength{ Str = newval, stu = stud };
						stren.Add(strval);
					}
					
					var dColC = ipData.Select(x => x.ColC).Distinct();
					foreach(var data in dColC)
					{
						prof.name = data;
						prof.strength = stren;                
					}
					Console.WriteLine(prof.name);
					foreach(var ss in prof.strength)
					{
						Console.WriteLine(ss.Str);
						foreach(var nn in ss.stu)
						{
							Console.WriteLine(nn.sid);							
						}
					}				   
				}
			}
