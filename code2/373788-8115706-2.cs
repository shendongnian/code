    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getPOI", WrapperNamespace="com.test", IsWrapped=true)]
    public partial class getPOI {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="com.test.poi", Order=0)]
        public int ID;
        
        public getPOI() {
        }
        
        public getPOI(int ID) {
            this.ID = ID;
        }
    }
