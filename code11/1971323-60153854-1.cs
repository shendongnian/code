mySearcher.PropertiesToLoad.Add("objectGUID");
mySearcher.PropertiesToLoad.Add("objectSID");
SearchResult searchResult = mySearcher.FindOne(); //FindAll() can return a collection
var objectGUID = searchResult.GetDirectoryEntry().Properties["objectGUID"].Value;
var computerGUID = searchResult.GetDirectoryEntry().Properties["objectSID"].Value;
**OR**
 mySearcher.PropertiesToLoad.Add("objectGUID");
 mySearcher.PropertiesToLoad.Add("objectSID");
 SearchResultCollection results;
 results = mySearcher.FindAll();
string sidStringValue="";
string guidStringValue="";
    foreach (var result in results)
    {
                  //reset SID
                  byte[] SID = null;
                  if (result.Properties[“objectSid”].Count > 0)
                  {
                      SID = (byte[]) result.Properties[“objectSid”][0];
                  }
                  sidStringValue = GetSidString(SID); 
             }//
`
**GetSidString** *Is a part of Unmanaged code so you'll have to P/Invoke*
[DllImport(“advapi32”, CharSet = CharSet.Auto, SetLastError = true)]
static extern bool ConvertSidToStringSid([MarshalAs(UnmanagedType.LPArray)] byte[] pSID, out IntPtr ptrSid);
 
public static string GetSidString(byte[] sid)
{
            IntPtr ptrSid;
            string sidString;
            if (!ConvertSidToStringSid(sid, out ptrSid))
                throw new System.ComponentModel.Win32Exception();
            try
            {
                sidString = Marshal.PtrToStringAuto(ptrSid);
            }
            finally
            {
                Marshal.FreeHGlobal(ptrSid);
            }
            return sidString;
}
**Note** : 
Second approach emphasizes on `objectSid` you'll have to modify it accordingly for `objectGUID`
**References:**
https://philippsen.wordpress.com/2010/12/07/retrieving-user-sid-using-directoryentry-and-directorysearcher/
