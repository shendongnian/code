namespace Notes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Colorr { get; set; }
        [Ignore]
        public Color  Colorrr { get; set; }
    }
}
You also have to initialize your `Colorrr` field before binding it to your view like this:
note.Colorrr = note.Colorr.FromHex(x);
Then it should work as expected
