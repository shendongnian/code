            try
            {
                // Overflow exception
                int maxNumber = int.MaxValue;
                maxNumber++;
            }
            catch (UnderflowException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            catch (OverflowException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }
