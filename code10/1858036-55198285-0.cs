    class Program
    {     
        // converts array of 0's and 1's to an int, and assumes big endian format.
        static int bitArrayToInt(int[] bit_array)
        {
            int rc = 0;
            for (int i = 0; i < bit_array.Length; i++)
            {
                rc <<= 1; // bit shift left
                rc |= bit_array[i]; // set LSB according to arr[i]. 
            }
            return rc;
        }        
        static void Main(string[] args)
        {
            int[] array = { 1, 0, 0, 1, 0 };
            int rc = bitArrayToInt(array);
           
            System.Console.WriteLine("{0} = {1} binary",rc, Convert.ToString(rc, 2));
            System.Console.ReadLine();   
        }
    }
