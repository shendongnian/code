    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Tamir.SharpSsh;
    
    namespace sftpex
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    SshExec exec = new SshExec(ipAddress, username, password);
                    Console.Write("Connecting...");
                    exec.Connect();
                    Console.WriteLine("OK");
                    if (exec.Connected)
                        Console.WriteLine(exec.Cipher);
    
                    while (true)
                    {
                        Console.Write("Enter a command to execute ['Enter' to cancel]: ");
                        string command = Console.ReadLine();
                        if (command == "") break;
                        string output = exec.RunCommand(command);
                        string[] m = output.Split('\n');
                        for(int i=0; i<m.Length; i++)
                            Console.WriteLine(m[i]);
                    }
                    Console.Write("Disconnecting...");
                    exec.Close();
                    Console.WriteLine("OK");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
