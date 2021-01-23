            while (!p.HasExited)
            {
                if (!p.StandardOutput.EndOfStream)
                {
                    errorBuilder.Append(p.StandardError.ReadToEnd());
                    outputBuilder.Append(p.StandardOutput.ReadToEnd());
                    Console.Write(p.StandardOutput);
                }
            }
