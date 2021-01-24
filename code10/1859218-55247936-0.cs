    var inputs = new List<string>(){
        "ASDF-123-ZXCV-456",
        "YUIO-123-BNNM-987",
        "QWER-123-LKJH-111",
        "A1234",
        "A456"
    };
    foreach(var input in inputs){
        //Linq
        bool isMatch = input[0]=='A' && input.Skip(1).All(x=>char.IsDigit(x));
        //tryparse
        bool isMatch2 = input[0]=='A' && int.TryParse(input.Substring(1),out _);   
    }
