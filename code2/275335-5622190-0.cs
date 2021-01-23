        if (this.IsTurnedOn)
        {
            Console.WriteLine("false - already on");
            return false;
        }
        else
        {
            DateTime date = Convert.ToDateTime(turnon.SystemSettingValue);
            Console.WriteLine("Turnontime: " + date);
            Console.WriteLine("currenttim: " + DateTime.Now);
            if (date > DateTime.Now)
            {
                Console.WriteLine("false");
                return false;
            }
            else
            {
                Console.WriteLine("true");
                return true;
            }
        }
