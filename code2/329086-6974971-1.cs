    public class Arithmetic : Problem<Arithmetic>
    {
        public override int ResultCount
        {
            get
            {
                return 2;
            }
        }
        public override bool CheckTheAnswer(params decimal[] results)
        {
            if(results.Length != ResultCount)
                throw new ArgumentException("Only expected " + ResultCount + " arguments.");
            ...
        }
    }
