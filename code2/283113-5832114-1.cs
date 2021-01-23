            var session = new SessionFactoryManager().CreateSessionFactory().OpenSession();
            var criteria = session.CreateMultiCriteria();
            //Find classes that inherit from BaseClass
            var classses = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(BaseClass));
            var searchValue = "Test";
            foreach (var classs in classses)
            {
                //Find all the properties that are typeof string
                var properties = classs.GetProperties()
                                       .Where(x => x.PropertyType == typeof(string));
                var query = DetachedCriteria.For(classs);
                foreach (var memberInfo in properties)
                {
                    query.Add(Restrictions.InsensitiveLike(memberInfo.Name, searchValue, MatchMode.Anywhere));
                }
                criteria.Add(query);
            }
            var results = criteria.List()
                                  .Cast<ArrayList>()
                                  .ToList()
                                  .SelectMany(x => x.ToArray())
                                  .Cast<BaseClass>()
                                  .ToList();
            foreach (var result in results)
            {
                Console.WriteLine(result.Id);
            }
