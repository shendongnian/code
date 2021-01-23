                test1(); // this would thro IOException
            }
            catch (IOException e)
            {
                booleanValue = true; // whatever you need to do next
            }
            finally
            {
                if (booleanValue)
                {
                    Console.WriteLine("Here");
                }
            }
