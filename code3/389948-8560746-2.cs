    public class ArrayListOutput : System.Collections.ArrayList
    {
        public override object this[int index]
        {
            get
            {
                Console.WriteLine(((decimal)index / (decimal)this.Count).ToString()); //Will output unformatted crude percentage
                return base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
