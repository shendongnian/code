    namespace Wmi
    {
        using System;
        class Program
        {
            static void Main()
            {
                try
                {
                    var exitStatus = WmiOperations.Run("notepad.exe", wait:10);
                    Console.WriteLine(exitStatus);
                }
                catch (Exception ex)
                {
                    var inn = ex;
                    while (inn != null)
                    {
                        Console.WriteLine(ex.GetType()+": "+inn.Message);
                        inn = inn.InnerException;
                    }
                }
                finally
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();    
                }                       
            }
        }
    }
