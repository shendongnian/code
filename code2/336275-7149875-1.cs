    public class Bar : Foo
    {
    }
    public static void CaseTypeSpecialized()
    {
         Foo obj = new Bar();
         CaseType(obj);
    }
