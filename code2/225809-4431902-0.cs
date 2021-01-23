    public class TempList
    {
        public TempList(string key1, string data1)
        {
            key = key1;
            data = data1;
        }
        public TempList()
        { }
        public string key;
        public string data;
    }
    {
        System.Collections.Generic.List<TempList> list1 = new System.Collections.Generic.List<TempList>();
            list1.Add(new TempList("NUMM", "1"));
            list1.Add(new TempList("DURC", "360"));
            list1.Add(new TempList("VORC", "2500"));
            System.Collections.Generic.List<TempList> list2 = new System.Collections.Generic.List<TempList>();
            list2.Add(new TempList("NUMM", "0"));
            list2.Add(new TempList("DURC", "340"));
            list2.Add(new TempList("VORC", "3000"));
            System.Collections.Generic.List<TempList> list3 = new System.Collections.Generic.List<TempList>();
            list3.Add(new TempList("NUMM", "false"));
            list3.Add(new TempList("DURC", "true"));
            list3.Add(new TempList("VORC", "false"));
            System.Collections.Generic.List<TempList> p = (from q in list1
                    join w in list2 on q.key equals w.key
                    join r in list3 on q.key equals r.key
                    select new TempList
                    {
                        key = q.key,
                        data = (r.data == "true") ? w.data : q.data
                    }).ToList<TempList>();
        }
