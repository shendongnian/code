    static void Main(string[] args)
        {
            string holder = "A B C D E";
            string[] searchTextLowerCase = holder.ToLower().Split(' ');
            using (Model1Container context = new Model1Container())
            {
                var q = context.Communities;
                List<Community> communities = q.Where(c => searchTextLowerCase.Contains(c.Name)).ToList();
            }
        }
