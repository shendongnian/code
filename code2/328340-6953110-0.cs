    using System.Diagnostics.Contracts;
    class TString10
    {
        private string value;
        
        …
        public static implicit operator TString10(string str)
        {
            Contract.Requires(str.Length <= 10);
            return new TString10 { value = str };
        }
        public static implicit operator string(TString10 str10)
        {
            Contract.Ensures(Contract.Result<string>().Length <= 10);
            return str10.value;
        }
    }
