    string content = "";
                for (var i = 0; i < 10000; i++)
                    content = String.Format("{0} asldkfjalskdfjlaskdfjalskdfj laksdf lkwiuirh 9238 r9849r8 49834", content);
    
                string test = String.Format("{0} find_me {0}", content);
    
                string search = test;
    
                var tickStart = DateTime.Now.Ticks;
                //6ms
                //var b = search.ToUpper().Contains("find_me".ToUpper());
    
                //2ms
                //Match m = Regex.Match(search, "find_me", RegexOptions.IgnoreCase);
                
    
                //a little bit over 1ms
                var c = false;
                if (search.Length == search.ToUpper().Replace("find_me".ToUpper(), "x").Length)
                    c = true;
                var tickEnd = DateTime.Now.Ticks;
                Debug.Write(String.Format("{0} {1}", tickStart, tickEnd));
