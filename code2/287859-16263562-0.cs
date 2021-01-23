    dTaskTemporaryDomain = AppDomain.CreateDomain("BUHLO_POBEDIT_ZLO");
            var currentAssembly = Assembly.GetExecutingAssembly();
            AdsApiHelper = (AdsApiHelper)_adTaskTemporaryDomain.CreateInstanceAndUnwrap(currentAssembly.GetName().FullName, typeof(AdsApiHelper).ToString());
            var members = AdsApiHelper.GetMembers(GroupName);
     AppDomain.Unload(_adTaskTemporaryDomain)
    ...
    [serializeble]
    class AdsApiHelper {
      GetMembers(String GroupName){
       .....
       return groupPrincipal.GetMembers().Select(m=>m.SamAccountName);
      }
