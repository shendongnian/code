    public class WaterConnectionManager
    {
        static IList<Pipe> WaterConnectedPipes = new List<Pipe>();
        static IList<Pipe> AllPipes = new List<Pipe>();
        static void UpdatePipes()
        {
            //get the starting point for this algorithm
            Pipe waterSource = GetWaterSource();
            //recurse for all connected pipes
            UpdateWaterConnectedPipesList(waterSource);
            
            //Update each pipe with its current status
            foreach(Pipe pipe in AllPipes)
            {
                pipe.IsWaterConnected = WaterConnectedPipes.Contains(pipe);
            }
        }
        static void UpdateWaterConnectedPipesList(Pipe sourcePipe)
        {
            //create a method that returns connected pipes on your Pipe script.
            IEnumerable<Pipe> connectedPipes = sourcePipe.GetConnectedPipes();
            
            foreach(Pipe connectedPipe in connectedPipes)
            {
                //prevent infinite recursion
                if (WaterConnectedPipes.Contains(connectedPipe))
                {
                    continue;
                }
                //store these connected pipes for later recursions/iterations
                WaterConnectedPipes.Add(connectedPipe);
                //recurse into the connected pipe, to find its connected pipes.
                UpdateWaterConnectedPipesList(connectedPipe);
            }
        }
        static Pipe GetWaterSource()
        {
            return AllPipes.First(p => p.IsWaterSource);
        }
    }
