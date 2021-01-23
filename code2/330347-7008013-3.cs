    public static void test1()
    {
    ..
                string[] linesw = obj1.ReadToEnd().Split(new char[] { '\n' });
                string firstline = linesw[1]; 
                test2(firstline);
    ..
    }
    
    public static void test2(string firstline)...
{
