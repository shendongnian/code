    Parallel.For(fromInclusive: 2, toExclusive: fPrime + 1, i =>
    {
        for (int j = 2; j <= fPrime; j++)
        {
            if (i != j && i % j == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
        {
            if (txt_result.InvokeRequired)
            {
                txt_result.Invoke((MethodInvoker)delegate { txt_result.Text = txt_result.Text + "..." + i; });
            }
            else
            {
                txt_result.Text = txt_result.Text + "..." + i;
            }
        }
        isPrime = true;
    });
    txt_result.Text = txt_result.Text + Environment.NewLine + "Done";
