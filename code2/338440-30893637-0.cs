    Given the Setting Enum Type is named `MyEnum`(in Company.Enums
    namespace), edit the return type to be of type `global::Company.Enums.MyEnum`:
    
            [global::System.Configuration.ApplicationScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("MySetting")]
            public global::Company.Enums.MyEnum MyEnum{
                get {
                    return ((global::Company.Enums.MyEnum)(this["MyEnum"]));
                }
            }
