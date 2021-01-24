    static void Main()
    {
    	var studentGrades = new StudentGrades(); // #1
        
        Console.WriteLine("Enter student name");
        var studentName = Console.ReadLine();
        Console.WriteLine("Enter midterm grade");
        var midtermGrade = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter final exam grade");
        var finalExamGrade = Convert.ToDouble(Console.ReadLine());
        var lettergrade = studentGrades.ReportCard(studentName, midtermGrade, finalExamGrade); // #2
    
        Console.WriteLine($"{studentName}'s grade is an {lettergrade}");
    }
