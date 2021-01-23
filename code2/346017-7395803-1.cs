            try
            {
                LJ.WriteLine("XXXXXXXXXXXX");
            }
            catch (InvalidException e)
            {
                LJ.WriteLine("YYYYYYYYYYYYYYYY");
                Console.WriteLine("Error: {0}", e.Message);
                return;
            }
