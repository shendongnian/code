    class Program
    {
        static void Main(string[] args)
        {
            int agentCount = 1000;
            int directoriesCount =100;
            int fileCount = 100;
            int dbFilesCount = 100;
            int j = 0;
            for (int i = 0; i < directoriesCount; i++)
            {
                Console.WriteLine("I : {0}", i);
                try
                {
                    while ((j < agentCount))
                    {
                        try
                        {
                           
                        }
                        catch (Exception exception)
                        { }
                        j++;
                        Console.WriteLine("J : {0}", j);
                    }
                    if (true)
                    {
                        //throw new InvalidOperationException("Some error"); UnComment and see
                        while (false)
                        {
                       
                        }
                        
                      
                        int r = 0;
                        for (int q = 0; q < fileCount; q++)
                        {
                            while ((r < dbFilesCount) )
                            {
                                r++;
                            }
                            try
                            {
                                if ((r >= dbFilesCount))
                                {
                                 
                                }
                            }
                            catch (Exception exception)
                            { }
                        }
                        j++;
                        Console.WriteLine("J : {0}", j);
                    }
                    else
                    {
                        
                        while (false)
                        {
                           
                        }
                        
                        for (int k = 0; k < fileCount; k++)
                        {
                            
                        }
                        
                    }
                }
                catch (Exception exception)
                {
                }
            }
            while (j < agentCount)
            {
                try
                {
                   
                }
                catch (Exception exception)
                { }
                j++;
                Console.WriteLine("J : {0}", j);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
            
        }
    }
