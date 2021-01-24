protected override void Seed(DbContext context)
{
   var landlords = context.Landlord.ToList();
   foreach(var landlord in loandlords){
     var user = new Users(){
         Name = landlord.FirstName,
         Surname = landlord.LastName,
         Email = landlord.Email
   }
   context.Users.Add(user); 
}
    base.Seed(context);
}
