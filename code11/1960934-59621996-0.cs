    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    // https://stackoverflow.com/questions/59621091/ef-core-3-0-convert-sql-to-linq
    public class Program
    {
    	public static void Main()
    	{
    		var enrollments = new List<Enrollments>
    		{
    			new Enrollments { StudentId = 1, CourseId = 1 },
    			new Enrollments { StudentId = 1, CourseId = 2 },
    			new Enrollments { StudentId = 1, CourseId = 3 },
    			new Enrollments { StudentId = 1, CourseId = 4 },
    			new Enrollments { StudentId = 1, CourseId = 5 },
    			new Enrollments { StudentId = 1, CourseId = 6 },
    			
    			new Enrollments { StudentId = 2, CourseId = 1 },
    			new Enrollments { StudentId = 2, CourseId = 2 },
    			new Enrollments { StudentId = 2, CourseId = 3 },
    			new Enrollments { StudentId = 2, CourseId = 4 },
    			new Enrollments { StudentId = 2, CourseId = 5 },
    		};
    		var courses = new []{1, 2, 3, 4, 5};
    		
    		var groupedEnrollment = enrollments.GroupBy(p => p.StudentId).Select(g => new 
    																			 {
    																				StudentId = g.Key,
    																				Courses = g.Select(p => p.CourseId).ToArray() 
    																			 });
    		var result = groupedEnrollment.Where(g => g.Courses.Length == courses.Length && g.Courses.Intersect(courses).Count() == courses.Length);
    		
    		foreach(var item in result)
    			Console.WriteLine(item.StudentId);
    	}
    	
    	public class Enrollments 
    	{
    		public int StudentId { get; set; }
    		public int CourseId  { get; set; }
    	}
    }
