    SshExec exec = new SshExec("host","user");
                exec.Password = "pass";
                //if (input.IdentityFile != null) exec.AddIdentityFile(input.IdentityFile);
    
                Console.Write("Connecting...");
                exec.Connect();
                Console.WriteLine("OK");
                while (true)
                {
                    Console.Write("Enter a command to execute ['Enter' to cancel]: ");
                    string command = "ls";
                    if (command == "") break;
                    string output = exec.RunCommand(command);
                    Console.WriteLine(output);
                }
                Console.Write("Disconnecting...");
                exec.Close();
                Console.WriteLine("OK");
    
        enter code here
