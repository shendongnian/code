    foreach (var change in this.Changes)
            {
                List<int> origin = this.Origins[change.Key];
                List<int> newValue = change.Value;
                //find the basic add and remove
                IEnumerable<int> remove = origin.Except(newValue);
                IEnumerable<int> add = newValue.Except(origin);
                if (!add.Any() && remove.Any())
                {
                  //remove all in the remove list 
                    continue;
                }
                else if (add.Any() && !remove.Any())
                {
                  //add all in the add list
                    continue;
                }
                //if in the same change there are add and remove 
                IEnumerable<int> dif1 = add.Except(remove);
                IEnumerable<int> dif2 = remove.Except(add);
                if (dif1.Any())
                {
                    //add all in the dif1 list 
                }
                if (dif2.Any())
                {
                    //remove all in  dif2 list
                }
            }
