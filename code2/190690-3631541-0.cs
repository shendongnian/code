    public class Box
    {
        private List<Box> myBoxes;
    
        public override IEnumerable<Box> GetAllBoxes()
        {
            yield return this;
            foreach(var box in myBoxes)
               yield return box.GetAllBoxes();
        }
    }
