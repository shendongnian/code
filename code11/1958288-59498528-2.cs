        public IEnumerable<object> EnumerateValueTuple(object valueTuple)
        {
            var tuples = new Queue<object>();
            tuples.Enqueue(valueTuple);
            while (tuples.Count > 0 && tuples.Dequeue() is object tuple)
            {
                foreach (var field in tuple.GetType().GetFields())
                {
                    if (field.Name == "Rest")
                        tuples.Enqueue(field.GetValue(tuple));
                    else
                        yield return field.GetValue(tuple);
                }
            }
        }
