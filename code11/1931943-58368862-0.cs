c#
protected void Page_Load(object sender, EventArgs e)
{
    int beforeInstantiation = Class1.countSAO; // output: 0
    Class1 myclass = new Class1();
    int afterInstantiation = Class1.countSAO; // output: 9017
    Class1.updatedCount(); // update the Static variable before calling
    int updatedSao = Class1.countSAO; // output 500
    int saoProperty = Class1.countSAOProperty; // output 9017
}
class Class1
{
    public static int countSAO; // this would not 
    public static int countSAOProperty
    {
        get
        {
            return SAO_Num.Count;
        }
    }
    // this will be called only when the class is instantiated using New Class1();
    public static List<int> SAO_Num
    {
        get
        {
            List<int> intlist = new List<int>();
            for (int i = 0; i < 9017; i++)
            {
                intlist.Add(i);
            }
            return intlist;
        }
    }
    // this will only run if class is Instantiate using New Class();
    public Class1()
    {
        countSAO = SAO_Num.Count;
    }
    public static void updatedCount()
    {
        countSAO = 500;
    }
}
