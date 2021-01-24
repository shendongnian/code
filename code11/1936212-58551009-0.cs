class Program
{
    // Add static keyword. Because Main() method is static. 
    // So, every variable inside it should be static.
    // public gameInfo[] gameInfoArray = new gameInfo[10];
    public static gameInfo[] gameInfoArray = new gameInfo[10];
    static void Main(string[] args)
    {
       ......
    }
}
### 2. Work with local variable
class Program
{    
    //public gameInfo[] gameInfoArray = new gameInfo[10];    
    static void Main(string[] args)
    {
       // Declare as local variable.
       // In static method will now complain using local variable.
       gameInfo[] gameInfoArray = new gameInfo[10];
       ......
    }
}
----
I've tried to run this code, plase don't forget initialize `gameInfoArray` to prevent null reference exception.
you may need this before entering for loop,
for (int index = 0; index < gameInfoArray.Length; index++)
{
   gameInfoArray[index] = new gameInfo();
}
