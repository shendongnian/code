 c#
var query = (from Users in _db.Users 
join pricing in _db.Prices
select new {
    Username = Users.Name,
    pricing.Currency, pricing.Amount
}).AsEnumerable().Select(x => new UsersPrice 
{
    Username = x.Username,
    Price = x.Currency + " " + x.Amount.ToString(...) // your choices here
});
where the relevant bit here is that in the *ORM* query I've just selected the columns, and **after** the `AsEnumerable()` I have the code that *formats* them.
