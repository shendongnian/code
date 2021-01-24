    static void Main()
    {
    	var studentGrades = new StudentGrades(); // #1
    	var studentName = "John Doe";
        var lettergrade = studentGrades.ReportCard(studentName, 69.9, 66.66); // #2
    
        Console.WriteLine($"{studentName}'s grade is an {lettergrade}");
    }
