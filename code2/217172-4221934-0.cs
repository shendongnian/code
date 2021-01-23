    static void Main(string[] args)
    {
        string FileToDelete = "test.txt";
        //sets system32 to system32 path
        string system32 = Environment.SystemDirectory + @"\";
        try
        {
            //check if file exists
            if (!File.Exists(system32 + FileToDelete))
            {
                //if it doesn't no need to delete it
                Console.WriteLine("File doesn't exist or is has already been deleted.");
                //Console.WriteLine(system32 + FileToDelete);
                Console.ReadLine();
            } //end if
            //if it does, then delete
            else
            {
                File.Delete(system32 + FileToDelete);
                Console.WriteLine(FileToDelete + " has been deleted.");
                Console.ReadLine();
            } //end else
        } //end try
        //catch any exceptions
        catch (Exception ex)
        {
            Console.WriteLine(Convert.ToString(ex));
            Console.ReadLine();
        } //end catch            
    }
