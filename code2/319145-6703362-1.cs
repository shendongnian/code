        static T ConvertToEnum<T>(object value)
        {
            return (T) Enum.Parse(typeof(T), Enum.GetName(typeof(T), value));             
        }
        static void Main(string[] args)        
        {             
            Gender g1 = ConvertToEnum<Gender>(0); //Male
            Gender g2 = ConvertToEnum<Gender>(1); //Female
            Gender g3 = ConvertToEnum<Gender>(2); //*BANG* exception             
        }
