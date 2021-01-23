    class Record
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    function ReadFullFile(Action<Record> processRecord)
    {
        using(var file = new FileStream("whatever.bin"))
        {
            using(var reader = new BinaryReader(file))
            {
                processRecord(new Record
                {
                    Id = reader.ReadInt32(),
                    Name = reader.ReadString(),
                });
            }
        }
    }
