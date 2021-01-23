        private void PrintResult(Func<Int32, Int32> f)
        {
            Debug.WriteLine(f.Invoke(1));
        }
        //In some other method
        PrintResult(n => n + 2); //prints 3
