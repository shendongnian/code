public static void main(string[] args)
{
  // Call AnotherClass method, by passing Zero()
  // or One() but without instatiate MyCLass
  AnotherClass.UseMyClass((new MyClass()).Zero);
}
