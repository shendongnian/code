    public class OuterContainer
    {
        public class InnerContainer
        {
            public static string Property
            {
                get { return "value"; }
            }
            public static int Field = 10;
        }
    }
    GetStructuredName(() => OuterContainer.InnerContainer.Property)
    GetStructuredName(() => OuterContainer.InnerContainer.Field)
