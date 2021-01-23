      public class IndexHolder
        {
            private static int m_Index = -1;
            public static int GetNext()
            {
                return m_Index++;
            }
            public static void Reset()
            {
                m_Index = -1;
            }
        }
