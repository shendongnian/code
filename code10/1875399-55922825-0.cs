    void Main()
    {
        var listOne = new List<dings>{
            new dings() {id = 1, name = "aaa"},
            new dings() {id = 2, name = "bbb"},
            new dings() {id = 3, name = "ccc"},
        };
    
        var listTwo = new List<bums>();
        foreach (var item in listOne)
        {
            listTwo.Add(
            new bums()
                {
                    idbums = item.id + 33,
                    namebums = item.name + "hoho"
                }
            );
        }
    }
    
    public class dings
    {
        public int id;
        public string name;
    }
    
    public class bums
    {
        public int idbums;
        public string namebums;
    }
