    public MyClass() {
        if (this.defaultAssembly) {
            this.MyFuncToCallFrmApp = ExternalClass1.Function;
        } else {
            this.MyFuncToCallFrmApp = ExternalClass2.Function;
        }
    }
