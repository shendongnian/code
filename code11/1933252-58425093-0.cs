    using(var context = new SMSClassesDataContext() ){
    var unsentsms = context.SMSsents.Where(x=>x.DateTimeSent == null);
    foreach(var sms in unsentsms){
       SendSMS(sms.To, sms.Message, out string smsexception);
       sms.DateTimeSent = DateTime.Now;
       context.SubmitChanges();
    }
    }
`
