    using (var client = new SshClient("my-vm.cloudapp.net", 22, "username", "password​"))
            {
                client.Connect();
                Console.WriteLine("it worked!");
                client.Disconnect();
                Console.ReadLine();
            }
