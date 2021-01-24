    private static void Main(string[] args)
            {
                BooDelegate boo1 = objects => 1;
                BooDelegate boo2 = objects =>
                {
                    Console.WriteLine("Boo!");
                    return null;
                };
                BooDelegate boo3 = objects => $"{objects[0]} World";
    
                Console.WriteLine(boo1.GetFuncOfInt()());
                boo2.GetAction()();
                Console.WriteLine(boo3.GetFuncOfStringString()("Hello"));
                Console.ReadLine();
            }
