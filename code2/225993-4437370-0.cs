    public struct Key // note the struct...
    {
        public static Key A(EnKey1 k1, EnKey2 k2)
        {
    	   Key k = new Key();
    	   k.Key1 = k1;
    	   k.Key2 = k2;
    	   return k;
        }
        public EnKey1 Key1;
        public EnKey2 Key2;
    }
    
    
    Dictionary<Key, string> dic = new Dictionary<Key, string>();
    dic.Add(Key.A(EnKey1.A1,EnKey2.B19), "test");
    Console.WriteLine(dic[Key.A(EnKey1.A1,EnKey2.B19)]); 
    // outputs "test"
    // then you can do:
    // dic.ContainsKey(Key.A(EnKey1.A1,EnKey2.B19)) -> true
    // dic.ContainsKey(Key.A(EnKey1.A2,EnKey2.B19)) -> false
