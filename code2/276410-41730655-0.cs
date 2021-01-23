    public Class1
    {
        public Form_Class formToOutput;
        public Class1(Form_Class f){
            formToOutput = f;
        }
        // Then call this method and pass whatever string
        private void Write(string s)
        {
            formToOutput.MethodToBeCalledByClass(s);
        }
    }
