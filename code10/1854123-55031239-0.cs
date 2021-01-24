using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
namespace ExportTest
{
    public class Softhsmtest
    {
        public static void Test()
        {
            using (Pkcs11 pkcs11 = new Pkcs11(@"C:\SoftHSM2\lib\softhsm2.dll", AppType.MultiThreaded))
            {
                Slot slot = pkcs11.GetSlotList(SlotsType.WithTokenPresent)[0];
                using (Session session = slot.OpenSession(SessionType.ReadWrite))
                {
                    session.Login(CKU.CKU_USER, "1111");
                    session.Logout();
                }
            }
        }
    }
}
