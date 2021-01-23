            bool executed = false;
            int counter = 0;
              
            while (!executed)
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    succes = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SERVER> (Error) Exception in AddTemplate() {0},{1}", ex.Source, ex.Message);
                    System.Threading.Thread.Sleep(100);
                }
                counter++;
            }
