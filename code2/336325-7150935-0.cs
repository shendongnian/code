    public class Aclass : System.Collections.Generic.Dictionary<string, int>
    {
        public Aclass(Aclass myAclass, System.Collections.Generic.HashSet<string> blacklist)
        {
            foreach (var item in myAclass)
            {
                int iCount = (from itemBlack in blacklist
                              where itemBlack == item.Key
                              select itemBlack)
                              .Count();
    
                if ((item.Value > 0) && (iCount == 0))
                {
                    Add(item.Key, item.Value);
                }
            }
        }
    }
