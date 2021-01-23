    var contact = new GoogleContacts() { ... };
    
    var vcf = new StringBuilder();
    vcf.Append("TITLE:" + contact.Title + System.Environment.NewLine); 
    //...
   
