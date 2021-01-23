    int len = 8;
    public string DeicmalToBin(int value, int len) 
    {
            try
            {
                return (len > 1 ? DeicmalToBin(value >> 1, len - 1) : null) + "01"[value & 1];
            }
            catch(Exception ex){
                Console.Write(ex.Message);
            }
            return "";
        }
