    public class Sample
    {
        public static List<int> staticList = new List<int>();
        public static void AGenericMethod<T>() where T : Sample
        {
            //This works just fine. The static variable is shared by Sample and Sample2
            //Just don't try to qualify it with the generic type.
            staticList.Add(3);
        }
    }
    public class Sample2 : Sample
    {
    }
