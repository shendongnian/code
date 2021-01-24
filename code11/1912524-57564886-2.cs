    public class ClassUnderTest {
        public ClassUnderTest(ISomeType dep) {
            dep.OnGetData += Dep_OnGetData;
        }
        public static bool Dep_OnGetData(string name, ref byte[] data) {
            data = System.Text.Encoding.UTF8.GetBytes(name);
            return true;
        }
    }
