try
{
   .....
}
catch(ArgumentNullException argumentNullException)
{
   throw new NewException("This is a custom exception message", argumentNullException);
}
Additionally, it is recommended that you catch the base System.Exception only in the top most control class. In the inner classes you should catch the specific exception types and use custom exception if required.
