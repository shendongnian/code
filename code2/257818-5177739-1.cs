    ArrayList ArrAcpayee = ChequeAcPayee.ChequeACpayee (DDLPayee.SelectedItem.ToString(), BDPSelectDate.SelectedDate);
    
    return ArrAcpayee.Cast<string>().Single(); //If there will always be just one value in the array list
    
    return ArrAcpayee.Cast<string>().SingleOrDefault(); //If there will be either one or no value in the array list
    
    return ArrAcpayee.Cast<string>().First(); //If you want to return the first value
