    foreach (var change in this.Changes)
            {
                List<int> origin = this.Origins[change.Key];
                List<int> newValue = change.Value;
                //find the basic add and remove
                IEnumerable<int> add = origin.Except(newValue);
                IEnumerable<int> remove = newValue.Except(origin);
                if (add.IsNullOrEmpty() && !remove.IsNullOrEmpty())
                {
                    //add all in the add list
                    continue;
                }
                else if (!add.IsNullOrEmpty() && remove.IsNullOrEmpty())
                {
                    //remove all in the remove list
                    continue;
                }
                //if in the same change there are add and remove 
                IEnumerable<int> dif1 = add.Except(remove);
                IEnumerable<int> dif2 = remove.Except(add);
                if (!dif1.IsNullOrEmpty())
                {
                    //remove all in the dif1 list 
                }
                if (!dif2.IsNullOrEmpty())
                {
                    //add all in  dif2 list
                }
            }
