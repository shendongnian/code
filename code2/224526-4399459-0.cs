        private void ActWithCast(MyEnum e)
        {
            const int interest = (int)MyEnum.A | (int)MyEnum.B;
            if (0 != ((int)e & interest))
            {
                Console.Out.WriteLine("Blam");
            }
        }
