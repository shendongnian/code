    // Pass the name of the sales rep
    static int SearchSeller(string[] sellerNames, int sellerCount, string salesRep)
        {
            try
            {
                int index = 0;
                bool found = false;
                                while (!found && index < sellerCount)
                {
                    // compare the current name in array with the passed name
                    if (salesRep == sellerNames[index])
                        found = true;
                    else
                        index++;
                }
                if (!found)
                    index = -1;
                return index;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            return 0;
            }
