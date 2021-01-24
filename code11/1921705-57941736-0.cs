public void A()
{
  using(var db = new DB())
  {
    foreach(var item in items)
     { B(db);}
  }
}
public void B(DB db)
{
   // some code using db
}
