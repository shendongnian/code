    public class ContainerGrid{
        public List<List<List<Container>>> Locations = new List<List<List<Container>>>();
        public List<Container> OrderedList;//you can keep sorting the containers and their current locations separate but still cleanly managed this way.
        public bool IsEmpty(int x, int y, int z){
            //interpreting what you said about needing to be empty and not valuable to be viable. 
            return containers[x][y][z].empty && !containers[x][y][z].valuable;
        }
        public bool IsEmptyAndNeighborsEmpty(int x, int y, int z){
            //i am unsure if you intended sides to be only in the x direction 
            //or if that was just a part of how you explained it in the question
            return IsEmpty(x,y,z) 
              && IsEmpty(x-1,y,z) && IsEmpty(x+1,y,z);
            //&& IsEmpty(x,y-1,z) && IsEmpty(x,y+1,z);
            //&& IsEmpty(x,y,z-1) && IsEmpty(x,y,z+1);
        }
    }
