    public void CheckGender(string pnr)
    {
        string arr = pnr.Substring(9, 1);
        int num =0;
        if (int.TryParse(arr, num))
        {
            if ((num % 2) == "0")
            {
                Console.WriteLine("Man!!!");
            }
            else
            {
                Console.WriteLine("Woman!!!");
            }
        }
        else
        {
            Console.WriteLine("Not a number!");
        }
    }
