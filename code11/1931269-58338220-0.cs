            //wil je meer vrienden in de array pas hier het aantal aan :)
            int vrienden = 2;
            //maak array. de comma in de brackets is voor meer items, eerste waarde voor hoeveel mensen, tweede aantal elementen
            string[,,,,] vriendenarray = new string[vrienden, 5,1,1,1];
            //^^ here i get the error code of cannot implicitly convert type 'string[*,*] to string[*,*,*,*,*]'
            Console.WriteLine("welkom bij het online vriendenboekje!");
            Console.WriteLine("hier kan je een antaal elementen van je vrienden opslaan");
            //vul de array met de elementen / vraag de mensen voor input
            for (int i = 0; i < vrienden; ++i)
            {
                Console.Write("Vul hier de naam in van je vriend -->");
                vriendenarray[i, 0, 0, 0, 0] = Console.ReadLine(); //<-- here i get the error message of wrong number of indices inside []
                Console.Write("Vul hier zijn/haar favoriete kleur in -->");
                vriendenarray[i, 1, 0, 0, 0] = Console.ReadLine();
                Console.Write("Vul hier zijn/haar favourite eten in -->");
                vriendenarray[i, 2, 0, 0, 0] = Console.ReadLine();
                Console.Write("Vul hier zijn/haar favourite seizoen in -->");
                vriendenarray[i, 3, 0, 0, 0] = Console.ReadLine();
                Console.Write("Vul hier zijn/haar favourite dier in -->");
                vriendenarray[i, 4, 0, 0, 0] = Console.ReadLine();
            }
            //leest/displayed wat er allemaal is ingevuld
            for (int i = 0; i < vrienden; i++)
            {
                Console.WriteLine("Vriend nummer {0} is {1} en zijn favoriete elementen zijn {2}{3}{4}", i, vriendenarray[i, 0, 0, 0, 0], vriendenarray[i, 1, 0, 0, 0], vriendenarray[i, 2, 0, 0, 0], vriendenarray[i, 3, 0, 0, 0], vriendenarray[i, 4, 0, 0, 0]);
            }
