    class TestTryCatch
    {
        static int GetInt(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (System.IndexOutOfRangeException e)  // CS0168
            {
                System.Console.WriteLine(e.Message);
                //set IndexOutOfRangeException to the new exception's InnerException
                throw new System.ArgumentOutOfRangeException("index parameter is out of range.", e);
            }
        }
    }
