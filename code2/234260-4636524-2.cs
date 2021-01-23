    private struct UnpackedAndPacked
    {
        public string Unpacked {get;set;}
        public string Packed {get;set;}
    }
    var ws = from w in query.Split()
             where !String.IsNullOrWhiteSpace(w)
             select new UnpackedAndPacked
                        {
                            Unpacked=w, 
                            Packed=PhoneNumber.Pack(w)
                        };  
