    public void DidStudentPass(int passMark)
    {
        if (Grade >= passMark)
        {
            Console.WriteLine("{0} {1} passed with a Grade of {2}.", FirstName, Lastname, Grade);
        }
        else
        {
            Console.WriteLine("{0} {1} failed with a Grade of {2}.", FirstName, Lastname, Grade);
        }
    }
