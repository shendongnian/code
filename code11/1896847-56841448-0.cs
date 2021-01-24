for (int i = 0; i < inputDigits.Length; i++)
{
    int j = inputDigits.Length - (i + 1);
    baseTen += (int)inputDigits[i] * (int)Math.Pow(inputBase, j);
}
