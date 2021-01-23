            Tmd a = new Tmd();
            a.em.i += 5;
            Console.WriteLine(a.em.i); // 5
            DoIt(a);
            Console.WriteLine(a.em.i); // 6
            DoIt(a.em);
            Console.WriteLine(a.em.i); // 6 (unchanged)
