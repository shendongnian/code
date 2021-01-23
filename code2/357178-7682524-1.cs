    var input = new string[3] { "PO BOX XXX                                       OVERDUE - PAY NOW  ", 
                                          "ClientB                                AMOUNT CARRI",
                                          "PO BOX 400                                                    FORWARD TO N  "
                                        };
            
        for (int x = 0, len = input.Length; x != len; x++)
        {
             input[x] = Regex.Replace(input[x], @"\s{3}[^\n]+", string.Empty);
        }
         //input is ["PO BOX XXX","ClientB","PO BOX 400"]
