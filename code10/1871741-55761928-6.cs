    public interface ICube {} // It's empty!
    public void DoSomethingWithTheseCubes(List<ICube> cubes)
    {
        foreach(var cube in cubes)
        {
            // what do I do with this cube?
        }
    }
