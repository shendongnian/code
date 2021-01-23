    public static void ReverseEachWordString(string abc)
    		{
                int start_index = 0, end_index = abc.Length - 1;
                int i = 0, j = 0;
                char[] arr = abc.ToCharArray();
                try
                {
                    while (start_index < end_index)
                    {
                        if (arr[start_index] == ' ')
                        {
                            Console.WriteLine(arr[start_index]);
                            start_index++;
                            i = start_index;
                        }
                        else
                        {
                            if (arr[i] != ' ')
                            {
                                if (i == end_index)
                                {
                                    i++;
                                    for (j = i - 1; j >= start_index; j--)
                                    {
                                        Console.WriteLine(arr[j]);
                                    }
                                    break;
                                }
                                else
                                    i++;
                            }
                            else
                            {
                                for (j = i - 1; j >= start_index; j--)
                                {
                                    Console.WriteLine(arr[j]);
                                }
                                i++;
                                start_index = i - 1;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }		
