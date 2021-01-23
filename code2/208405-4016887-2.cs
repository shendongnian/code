    class Program
        {
            static void Main(string[] args)
            {
                SerialNumber first = new SerialNumber("56AAA7105A25");
                SerialNumber second = new SerialNumber("57AAA71064C6");
                SerialNumber third = new SerialNumber("58AAA71064D6");
    
                Console.WriteLine(first.CompareTo(second));
                Console.WriteLine(second.CompareTo(third));
    
                Console.ReadLine();
            }
        }
    
        struct SerialNumber : IComparable<SerialNumber>
        {
            public string Serial { get; set; }
            
    
            public SerialNumber(string serial) : this()
            {
                this.Serial = serial;
            }
    
            public int CompareTo(SerialNumber other)
            {
                int compareTo = 0;
            
                using (CharEnumerator enum1 = Serial.GetEnumerator())
                using (CharEnumerator enum2 = other.Serial.GetEnumerator())
                {
                    while (enum1.MoveNext() && enum2.MoveNext())
                    {
                        if (enum1.Current != enum2.Current)
                        {
                            compareTo = enum1.Current.CompareTo(enum2.Current);
                            break;
                        }
                    }
                }
                return compareTo;
            }
        }
