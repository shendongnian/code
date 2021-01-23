    //Assumes they are sorted on item1
            Tuple<IEnumerable<Tuple<int,int>>,IEnumerable<Tuple<int,int>>> FindMissingAndOverLapping(IEnumerable<Tuple<int,int>> sequences){
                var previous = Tuple.Create(0, 0);
                var missing = new List<Tuple<int,int>>();
                var overlapping = new List<Tuple<int, int>>();
                var max = 0;
                foreach (var sequence in sequences){
                    var end = previous.Item2;
                    max = end > max ? end : max;
                    if (previous.Item2 < sequence.Item1 + 1){
                        missing.Add(Tuple.Create(previous.Item2 + 1, sequence.Item1 - 1));
                    } else if (max < sequence.Item1){
                        overlapping.Add(Tuple.Create(sequence.Item1, max));
                    }
                }
                //The sequences in ovrelapping can be ovrelapping them self
                return new Tuple<IEnumerable<Tuple<int,int>>,IEnumerable<Tuple<int,int>>>(missing, overlapping);
            }
