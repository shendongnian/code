    public class Moon : CelestialBody
    {
        //Moon-only properties here.
    }
    public class Planet : CelestialBody
    {
        //Planet-only properties here.
        public List<Moon> Moons { get; set; }
    }
