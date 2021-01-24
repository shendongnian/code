        static Human Convert(Person p)
        {
            var result = new Human() { Name = p.Name, Age = 12 };
            if (p.Childs?.Any() == true)
            {
                result.SubHuman = new List<Human>();
                p.Childs.ForEach(x => result.SubHuman.Add(Convert(x))); //Recursion here
            }
            return result;
        }
