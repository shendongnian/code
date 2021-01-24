    using System;
    					
    public class Program
    {
    	public static void NameSurnameGrade2()
        {
            string name = "John";
            string surname = "Doe";
            int grade = 12;
            Console.WriteLine(string.Format("Name: {0}, Lastname: {1}, Grade: {2}", name, surname, grade));
        }
    	
    	public static void Main()
    	{
    		NameSurnameGrade2();    
            Console.ReadLine();
    	}
    }
