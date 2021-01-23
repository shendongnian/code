            static void Main(string[] args)
            {
                Random rnd = new Random(unchecked((int)(DateTime.Now.Ticks)));
                //DEBUG:rnd = new Random(1);
                string str = "{Hello|Hi} {World|People}! {C{#|++|}|Java} " +
                    "is an {awesome|amazing} language.";
                Console.WriteLine(spintax(rnd, str));
                Console.ReadLine();
            }
        }
    }
