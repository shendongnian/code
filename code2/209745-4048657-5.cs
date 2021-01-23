    var inst = new SomeObject();
    int result2 = Extensions.ANewFakeInstanceMethod(inst, "str");
    public static class Extensions
    {
        public static int ANewFakeInstanceMethod(SomeObject instance, string someParam)
        {
            return 0;
        }
    }
