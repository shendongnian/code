       1: /// <summary>
       2: /// Performs actions on the network
       3: /// </summary>
       4: public sealed class NetworkHandler
       5: {
       6:     /// <summary>
       7:     /// Private constructor to prevent compiler from generating one
       8:     /// since this class only holds static methods and properties
       9:     /// </summary>
      10:     NetworkHandler() { }
      11:  
      12:     /// <summary>
      13:     /// SafeNativeMethods Class that holds save native methods 
      14:     /// while suppressing unmanaged code security
      15:     /// </summary>
      16:     [SuppressUnmanagedCodeSecurityAttribute]
      17:     internal static class SafeNativeMethods
      18:     {
      19:         // Extern Library
      20:         // UnManaged code - be careful.
      21:         [DllImport("wininet.dll", CharSet = CharSet.Auto)]
      22:         [return: MarshalAs(UnmanagedType.Bool)]
      23:         private extern static bool 
      24:             InternetGetConnectedState(out int Description, int ReservedValue);
      25:  
      26:         /// <summary>
      27:         /// Determines if there is an active connection on this computer
      28:         /// </summary>
      29:         /// <returns></returns>
      30:         public static bool HasActiveConnection()
      31:         {
      32:             int desc;
      33:             return InternetGetConnectedState(out desc, 0);
      34:         }
      35:     }
      36: }
