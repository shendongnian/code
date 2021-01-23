    public class Process : IComparable 
    {
        int last_prediction;
        public int CompareTo(object obj)
        {
                Process right = obj as Process;
                return this.last_prediction.CompareTo(right.last_prediction);
        }
    }
