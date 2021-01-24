    create table CodeExamples(Id int identity(1,1), Code varchar(max));
    insert into CodeExamples(Code) select 'public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello, world!");
		}
	}';
    select * from CodeExamples;
