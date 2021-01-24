public void A()
{
  using(var db = new DB())
  {
    foreach(var item in items)
    { 
      //presumably this loop body will also do something with item
      B(db);
    }
  }
}
public void B(DB db)
{
   // some code using db
}
//in response to your comment. Maybe also make the B above as private
public void B()
{
    using(DB db){
      B(db);
    }
}
Your second form cannot work because a `using` block disposed of the variable when it finishes. You could however consider overriding dispose on your class so that your class wide db is disposed when your class is disposed, if you want to have a class wide db that lives for the life of your class. Ultimately this comes down to the lifecycle you want your class and the instances inside it, to have
Typically when the (more modern of the) systems I work on are implementing this data layer pattern, such as some Reader, they will take a db context via constructor parameter (dependency injection) and keep it for the life of the class, rather than each method making their own context in a using
