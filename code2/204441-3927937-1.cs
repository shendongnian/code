            dynamic ses = new MySession();
            ses.number = 5;
            ses.boolean = true;
            Console.WriteLine(ses.number > 4);
            if (ses.boolean)
            {
                Console.WriteLine(ses.number - 1);
            }
            Console.ReadKey();
