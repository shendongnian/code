    public class Hold
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //In some method or main console app:
    var holds = new List<Hold> { new Hold { Id = 1, Name = "Me" }, new Hold { Id = 2, Name = "You" } };
    var anonymousProjections = holds.Select(x => new { SomeNewId = x.Id, SomeNewName = x.Name });
    var namedTuples = holds.Select(x => (TupleId: x.Id, TupleName: x.Name));
