<pre>
App_DAL.DataDataContext h = new App_DAL.DataDataContext();
if ((from emails in MyTables where emails.pk_email == email select emails.pk_email).Any()) {
    //Then update your data here
    var messenger = (from emails in MyTables where emails.pk_email == email select emails).Single();
    messenger.last_login = DateTime.Now;
    messenger.is_logged_in = true;
    h.SubmitChanges();
}
else 
{
    //Insert your data
    App_DAL.MyTable msg = new App_DAL.MyTable();
    msg.pk_email = email;
    msg.is_logged_in = true;
    msg.last_login = DateTime.Now;
    h.MyTables.InsertOnSubmit(msg);
    h.SubmitChanges();
}
</pre>
