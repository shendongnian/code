        public static int serch_Acount(List<Accounts> AllAccount)
        {
            int pointer = default; // does not need
            Console.WriteLine("please enter the id number");
            int idSerch = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < AllAccount.Count; i++)
            {
                if (idSerch == AllAccount[i].id)
                {
                    Console.WriteLine("name: " + AllAccount[i].accountName);
                    Console.WriteLine("id: " + AllAccount[i].id);
                    Console.WriteLine("age: " + AllAccount[i].age);
                    Console.WriteLine("balance: " + AllAccount[i].balance);
                    pointer = i; // does not need
                    return pointer;
                    // return i;
                }
                Console.WriteLine("id doent found");
                pointer = -1; // does not need
            }
            return pointer;
            // return -1;
        }
