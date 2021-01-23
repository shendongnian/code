            .....
            P2.Start();
            StreamWriter ExeInput = P2.StandardInput;
            StreamReader ExeOutput = P2.StandardOutput;
            do
            {
                var k = P2.StandardOutput.Read();
                var key = Convert.ToChar(k);
                if (key == Convert.ToChar(ConsoleKey.Enter))
                {
                    Console.WriteLine();
                    ExeInput.Write("\n");
                }
                else
                    ExeInput.Write(key);
            } while (!P2.HasExited);
            ....
