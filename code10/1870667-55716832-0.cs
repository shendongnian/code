    namespace SpRestUtility
{
    class Class1
    {
        SpRestUtilities myUT = new SpRestUtilities();
        Class1() {
            myUT.SiteUrl = "https://yoursharepoint.com/yoursite";
            myUT.Credentials = new NetworkCredential("USERNAME", "PASSWORD");
        SpList listA = myUT.Get_SpList_By_Title("LISTNAME");
    }
    }
