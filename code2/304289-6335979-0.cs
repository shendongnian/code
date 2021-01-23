     static class BadIdea
        {
            public static Typ GetValue<Typ>(this object o, string PropName)
            {
    
                Type T = o.GetType();
                Typ ret = default(Typ);
                System.Reflection.PropertyInfo pi = T.GetProperty(PropName);
                if (pi != null)
                {
                    object tempRet = pi.GetValue(o, new object[] { });
                    ret = (Typ)Convert.ChangeType(tempRet, ret.GetType());
                }
                else
                {
                    return default(Typ);
                }
                return ret;
            }
            public class Tst
        {
            public int A { get; set; }
            public int B { get; set; }
        }
        static void Main(string[] args)
        {
            List<Tst> vals =new List<Tst>() { new Tst() { A = 4, B = 6 }, new Tst() { A = 4, B = 7 } };
            var lst = vals.Where((x) => x.GetValue<int>("A") == 4);
            foreach (Tst ot in lst)
            {
                Console.WriteLine("A : {0} ; B: {1}", ot.A, ot.B);
            }
        }
