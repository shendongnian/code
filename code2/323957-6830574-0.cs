    bool[] trueOrFalse = new bool[] { true, false };
            int[] para1 = new int[] { 1, 2, 3 };
            int[] para2 = new int[] { 5, 6, 7 };
            int[] para3 = new int[] { 1, 2, 3 };
            int[] para4 = new int[] { 5, 7, 9 };
    
            List<object> test = (from a in trueOrFalse
                                 from b in para1
                                 from c in para2
                                 from d in para3
                                 from g in para4
                                 let f = c - d
                                 where c - d <= 3
                                 select new { a,  b,  c, d, g,  f }).AsEnumerable<object>().ToList();
            foreach (object item in test)
            {
                Response.Write(item.GetType().GetProperty("a").GetValue(item, null).ToString()); 
            }
