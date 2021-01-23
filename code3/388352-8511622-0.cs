    public FillArray(int amountx)
    {
      numbers = new byte[amountx]
      Generator.NextBytes(numbers);
      numbers2 = new byte[amountx];
      numbers2 = numbers; // this line is why the arrays are the same
      amount = amountx;
    }
