            //Setup the initial predicate obj then stack on others:
            basePredicate = basePredicate.And(p => false);
            var predicate1 = PredicateBuilder.True<Person>();
            foreach (SearchParms parm in parms)
            {
                switch (parm.field)
                {
                    case "firstname":
                        predicate1 = predicate1.And(p => p.FirstName.Trim().ToLower().Contains(sValue));
                        break;
                    //etc...
                }
            }
            //Run a switch based on your and/or parm value to determine stacking:
            if (Parm.isAnd) {
                 basePredicate = basePredicate.And(predicate1);
            } else {
                 basePredicate = basePredicate.Or(predicate1);
            }
