        private void StepThroughDirectories(string dir, int depth)
        {
            if (depth < 0)
                return;
            string[] directories = Directory.GetDirectories(dir);
            try
            {
                foreach (string d in Directory.GetDirectories(dir))
                {
                    // your code here
                    Console.WriteLine("{0}", d);
                    StepThroughDirectories(d, depth-1);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } 
