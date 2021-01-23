    namespace Enums {
        static class SecurityRight {
            const String A = "A";
            const String B = "B";
        }
    }
    
    [MyAtt(StringProperty = Enums.SecurityRight.A + "&" + Enums.SecurityRight.B)]
