    public class Car
    {
        public virtual long CarId { get; set; }
        public virtual string Name { get; set; }
        public virtual byte[] LastModified { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Last Modified: {2}", CarId, Name, LastModified);
        }
    }
    public class CarMap : ClassMapping<Car>
    {
        public CarMap()
        {
            Table("Cars");
            Id(car => car.CarId, mapper => mapper.Generator(Generators.Identity));
            Property(car => car.Name);
            Version(car => car.LastModified, mapper =>
                                                 {
                                                     mapper.Generated(VersionGeneration.Always);
                                                     mapper.Type<BinaryTimestamp>();
                                                 });
        }
    }
