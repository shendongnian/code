    try
                {
                    throw new System.ArgumentException();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Value does not fall within the expected range.");
                    Console.WriteLine("Enter another temperature or 999 to quit");
                    comfort = false;
                    return comfort;
                }
