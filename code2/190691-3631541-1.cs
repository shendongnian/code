    public class Box
    {
        private List<Box> myBoxes;
        public IEnumerable<Box> GetAllBoxes()
        {
            yield return this;
            foreach (var box in myBoxes)
            {
                var enumerator = box.GetAllBoxes().GetEnumerator();
                while(enumerator.MoveNext()) 
                    yield return enumerator.Current;
            }
        }
    }
