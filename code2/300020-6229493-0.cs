        interface IProtocolClient
        {
            void connect(ParamType p);
        }
        class ParamType
        {
            public Type1 t1 { get; set; }
            public Type2 t2 { get; set; }
            public Type3 t3 { get; set; }
        }
=>
        class A : IProtocolClient
        {
            public void connect(ParamType p)
            {
                //do something with p.t1, p.t2, p.t3
            }
        }
        class B : IProtocolClient
        {
            public void connect(ParamType p)
            {
                var p2 = p as DerivedParamType;
                if (p2 == null)
                    throw new ApplicationException("p must be of type DerivedParamType");
                //do something with p2.t1, p2.t2, p2.t3, p2.t4
            }
        }
        class DerivedParamType : ParamType
        {
            public Type4 t4 { get; set; }
        }
