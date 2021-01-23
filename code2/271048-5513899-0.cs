            var grouped = filter.GroupBy(item => item.KeyWordGroup, item => item.KeyWords);
            foreach (var item in grouped)
            {
                var innerPredicate = PredicateBuilder.True<Product>();
                foreach (var inner in item)
                {
                    innerPredicate = innerPredicate.Or(p => item.Contains(k));  
                }
                predicate = predicate.And(innerPredicate);  //not sure this is correct as dont have IDE..
            }
