    public class Titel
    {
        public string title { get; set; }
    }
    public class Data
    {
        public Titel komik_popular { get; set; }
        public Titel buku_baru { get; set; }
    }
    public class RootObject
    {
        public Data data { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = "{'data':{'komik_popular':{'title':'Yei! Komik Awas Nyamuk Jahat jadi literasi terpopuler minggu ini lho!'},'buku_baru':{'title':'Ada buku baru nih, Katalog Prasekolah'}}}";
            List<RootObject> dataList = JsonConvert.DeserializeObject<List<RootObject>>(s);
        }
    }
