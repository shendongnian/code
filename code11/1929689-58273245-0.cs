    public class Obj
    {
        public string serial { get; set; }
        public int amount { get; set; }
        public int? newAmount { get; set; }
        public Status status { get; set; }
    }
    public enum Status
    {
        undefined,
        changed,
        deleted,
        @new
    }
    static void Main(string[] args)
        {
            string listOneJson = @"[
                                    { 
                                        serial: '63245-8',
                                        amount:  10
                                    },
                                    { 
                                        serial: '08657-5',
                                        amount:  100
                                    }
                                    ,
                                    { 
                                        serial: '29995-0',
                                        amount:  500
                                    }
                                ]";
            string listTwoJson = @"[
                                    {
                                        serial: '63245-8',
                                        amount: 100
                                    },
                                    {
                                        serial: '67455-1',
                                        amount: 100
                                    }
                                    ,
                                    {
                                        serial: '44187-10',
                                        amount: 50
                                    }
                                   ]";
            IList<Obj> listOne = JsonConvert.DeserializeObject<IList<Obj>>(listOneJson);
            IList<Obj> listTwo = JsonConvert.DeserializeObject<IList<Obj>>(listTwoJson);
            var result = merge(listOne, listTwo);
        }
     public static IEnumerable<Obj> merge(IList<Obj> listOne, IList<Obj> listTwo)
     {
           
            List<Obj> allElements = new List<Obj>();
            allElements.AddRange(listOne);
            allElements.AddRange(listTwo);
            IDictionary<string, int> dict1 = listOne.ToDictionary(x => x.serial, x => x.amount);
            IDictionary<string, int> dict2 = listTwo.ToDictionary(x => x.serial, x => x.amount);
            IDictionary<string, Obj> dictResults = new Dictionary<string, Obj>();
            foreach (var obj in allElements)
            {
                string serial = obj.serial;
                if (!dictResults.ContainsKey(serial))
                {
                    bool inListOne = dict1.ContainsKey(serial);
                    bool inListTwo = dict2.ContainsKey(obj.serial);
                    
                    Obj result = new Obj { serial = serial };
                    
                    if (inListOne && inListTwo) {
                        result.status = Status.changed;
                        result.amount = dict1[serial];
                        result.newAmount = dict2[serial];
                    }
                    else if (!inListOne && inListTwo)
                    {
                        result.status = Status.@new;
                        result.amount = dict2[serial];
                    }
                    else if (inListOne && !inListTwo)
                    {
                        result.status = Status.deleted;
                        result.amount = dict1[serial];
                    }
                    dictResults.Add(serial, result);
                }
            }
            return dictResults.Values;
       }
