    public class Implementation
        {
            public List<string> GetAllBadElements()
            {
                List<string> output = new List<string>;
    
                Element _wall = new Wall("wall");
                Element _floor = new Floor("floor");
                List<string> badWalls = _wall.GetBadParameters(); //Returns Wall bad Parameters
                List<string> badFloors = _floor.GetBadParameters(); //Returns Floor bad Parameters
    
                output = output.AddRange(badWalls).AddRange(badFloors);
                return output;
            }
        }
