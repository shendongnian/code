    int rows = 5;
    StringBuilder sb = new StringBuilder();
    // top part
    for (int i = 1; i <= rows; i++)
    {
        for (int j = 1; j <= rows - i; j++)
            sb.Append(' ');
        for (int k = 1; k <= 2 * i - 1; k++)
            sb.Append('*');
        sb.AppendLine();
    }
    //bottom part
    for (int n = rows - 1; n > 0; n--)
    {
        for (int l = 1; l <= rows - n; l++)
            sb.Append(' ');
        for (int m = 1; m <= 2 * n - 1; m++)
            sb.Append('*');
        sb.AppendLine();
    }
    Console.Write(sb.ToString());
