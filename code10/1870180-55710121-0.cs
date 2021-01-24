    Console.WriteLine("Input username:");
                string username = Console.ReadLine();
                Console.WriteLine("Input password:");
                SecureString password = new SecureString();
                password = Classes.Functions.GetPassword();
                Classes.Functions.runProcRasdial("VPN_Arta", username, password);
                Console.Clear();
                Console.WriteLine("VPN Connected.");
