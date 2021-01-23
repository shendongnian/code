    //constructor
    public myClass() {}
    //base method
    /**public string myfunction(string id, string pk) {return results;}**/
    //overloading method 1
    /**public string myfunction(string id, string pk, string param1) { return results;}**/
    //just use 1 method, but make the last two arguments optional by setting default values
    public string myfunction(string id, string pk, string param1 = "", string param2 = "") {return results;}
    [ComRegisterFunctionAttribute]
        public static void RegisterFunction(Type type)
        {
            Registry.ClassesRoot.CreateSubKey(
              GetSubKeyName(type, "Programmable"));
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(
              GetSubKeyName(type, "InprocServer32"), true);
            key.SetValue("",
              System.Environment.SystemDirectory + @"\mscoree.dll",
              RegistryValueKind.String);
        }
        [ComUnregisterFunctionAttribute]
        public static void UnregisterFunction(Type type)
        {
            Registry.ClassesRoot.DeleteSubKey(
              GetSubKeyName(type, "Programmable"), false);
        }
        private static string GetSubKeyName(Type type,
          string subKeyName)
        {
            System.Text.StringBuilder s =
              new System.Text.StringBuilder();
            s.Append(@"CLSID\{");
            s.Append(type.GUID.ToString().ToUpper());
            s.Append(@"}\");
            s.Append(subKeyName);
            return s.ToString();
        }
}
