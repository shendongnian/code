     public static List<string> sao_num = new List<string>();
     public static List<string> SAO_Num {
                get {
                    Console.WriteLine("Grabbing value of SAO_NUM: " + (sao_num == null ? "null" : "" + sao_num.Count));
                    return sao_num;
                }
                set
                {
                    Console.WriteLine("Setting value of SAO_NUM to: " + (value == null ? "null" : "" + value.Count));
                    sao_num = value;
                }
            }
