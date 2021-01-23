    public class Holder    {
        static public Holder[] InitArray(ulong length) {
            Holder[] holders = new Holder[length];
            for (ulong i = 0; i < length; i++) {
                holders[i] = new Holder;
            }
            return holders;
        }
    }
    ...
    var valueHolders = Holder.InitArray(n);
