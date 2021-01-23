    [Serializable]
        [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict)]
        public class PropInj : InstanceLevelAspect
        {
    #if SILVERLIGHT
            [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore, IsVirtual=true, Visibility=Visibility.FamilyAndAssembly)]
            public string MyProperty { get; set; }
    #else
            [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore, IsVirtual = true, Visibility = Visibility.Private)]
            public string MyProperty { get; set; }
    #endif
        }
    
        [PropInj]
        public class test
        {
            //public int MyProperty { get; set; }
    
            public test()
            {
                
            }
    
        }
