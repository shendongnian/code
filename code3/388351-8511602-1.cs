    class FillArray
    {
    
        public byte[] numbers;
        public byte[] numbers2;
    
        //instantiate MS Random object
        Random Generator = new Random();
    
        //Constructor which takes array size
        public FillArray(int amountx)
        {
            numbers = new byte[amountx]
            Generator.NextBytes(numbers);
            numbers2 = new byte[amountx];
            
            // Array Copy solution
            Array.CopyTo(numbers2, 0);
            // Or a LINQ solution
            numbers2 = numbers.ToArray();
            // Or a Clone solution
            numbers2 = (byte[])numbers.Clone();
            amount = amountx;
        }
    }
