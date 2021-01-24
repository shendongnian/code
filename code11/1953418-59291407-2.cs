foreach (Email item in emailList.emails)
{
    // This IF statement will either be true of false for ALL items.
    if (!Cmmd.Parameters["p_retorno"].Value.ToString().Equals("0")) 
    {
        emailList.moveMail(item.id, emailList.config.PathError);
    }
    else
    {
        emailList.moveMail(item.id, emailList.config.PathSuccess); 
    }
}
EDIT:<br> For new code you posted, try this to move all emails that contain any string from statusList in its body.
    // This will move all emails that have one or more statusList in their body
    foreach (Email item in emailList.emails)
    {
        if (statusList.Where(x => item.body.Contains(x)).Count > 0)
        {
            emailList.moveMail(item.id, emailList.config.PathSuccess);
            break; // This statement will stop processing of any other emails.
        }
    }
