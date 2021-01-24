private static bool HandleError(string message) { // More generic handling
   Console.WriteLine(message);
   Console.ReadLine();
   return true;
}
private static bool ManageStudents()
{
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine(" Choose an option:");
        Console.WriteLine("  1. Add a new student");
        Console.WriteLine("  2. View all students");
        Console.WriteLine("  3. Search students");
        Console.WriteLine("  4. Delete students");
        Console.WriteLine("  5. Update students");
        Console.WriteLine("  6. Back to main menu");
        Console.WriteLine("========================");
        Console.Write("\r\nPlease choose: ");
        try
        {
            switch (Console.ReadLine())
            {
                case "1":
                    AddStudents();
                    return true;
                case "2":
                    ViewStudents();
                    return true;
                case "3":
                    SearchStudents();
                    return true;
                case "4":
                    DeleteStudents();
                    return true;
                case "5":
                    UpdateStudents();
                    return true;
                case "6":
                    return false;
                default:
                    return HandleError("Out of range"); // Not in range 1-6
            }
        }
        catch (Exception e) // This catch exception happening in the all switch
        {
            return HandleError("Execution problem");
        }
    }
