    public static class Extensions
    {
        public static float[] SuperFoo(this FooObject foo, float[] floats)
        {
            foo.FillFoos(floats);
            return floats;
        }
    }
