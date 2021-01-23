                    var cscl = CSC.GetCodes();
    
                    for (int i = 1; i <= cscl.Count(); i++) {
                        object item = i;
                        var code = cscl.Item(ref item);
    
                        List.Add(new CSCCode((string)code.Name, Convert.ToString(code.Code)));
