SqlInsert("registrations", new Dictionary&lt;string, string&gt;()
{
    { "LoginEmail", txtLoginEmail.Text },
    { "Password", txtLoginPassword.Text },
    { "ContactName", txtContactName.Text },
    { City", txtCity.Text }
});
