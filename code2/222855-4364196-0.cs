        foreach (String s in names)
        {
            try
            {
                if (s == "MRUList")
                {
                    continue;
                }
                else
                {
                    String val = rk.GetValue(s);
                    Console.WriteLine(s + " Contains the value of : " + val);
                }
            }
            catch (Exception MyError)
            {
                Console.WriteLine("An error has occurred: " + MyError.Message);
            }
            Console.WriteLine("-----------------------------------------------");
        }
        rk.Close();
