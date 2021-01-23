    [DataContract]
    public class Coordinates
    {
        [DataContract]
        public struct CoOrd
        {
            public CoOrd(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            [DataMember(Order = 1)]
            int x;
            [DataMember(Order = 2)]
            int y;
            [DataMember(Order = 3)]
            int z;
        }
        [DataMember(Order = 1)]
        public List<CoOrd> Coords = new List<CoOrd>();
        public void SetupTestArray()
        {
            Random r = new Random(123456);
            List<CoOrd> coordinates = new List<CoOrd>();
            for (int i = 0; i < 1000000; i++)
            {
                Coords.Add(new CoOrd(r.Next(10000), r.Next(10000), r.Next(10000)));
            }
        }
    }
