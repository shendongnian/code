    public static string GenerateSessionID()
        {
            char[] characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            Random r = new Random();
            System.Threading.Thread.Sleep(10);
            string randomstring = "";
            for (int i = 0; i < 20; i++)
            {
                randomstring += characters[r.Next(0, 60)].ToString();
            }
            
            return randomstring;
        }
