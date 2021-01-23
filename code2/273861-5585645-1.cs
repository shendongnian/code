    Class a
    {
        main()
        {
            bool done = false;
            Console.CancelKeyPress += (s, e) => { done = true; e.Cancel = true; };
            while(!done)
            {
                f(a);
                g(b);
                if (Console.KeyAvailable)
                {
                    switch(Console.ReadKey().KeyChar)
                    {
                        case 'i':
                        case 'I':
                            DoSomethingImportant();
                            break;
                        case 'E':
                        case 'e':
                            done = true;
                            break;
                    }
                }
            }
        }
    }
