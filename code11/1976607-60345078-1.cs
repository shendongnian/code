    private void calculateButton_Click(object sender, EventArgs e)
            {
                int startNumber, endNumber, counter, num;
                startNumber = Convert.ToInt32(minValue.Text);
                endNumber = Convert.ToInt32(maxValue.Text);
                int startNumCounter = startNumber;
                for (num = startNumCounter; num <= endNumber; num++)
                {
                    output.Text += $"Factors {num}:";
                    counter = 0;
                    int numCurrent = num;
    
                    for (int i = 2; i <= numCurrent; i++)
                    {
                        bool continueToNexti = false;
                        while (!continueToNexti)
                        {
                            if (numCurrent % i == 0)
                            {
                                output.Text += $" {i} ";
                                numCurrent = numCurrent / i;
                                counter++;
                            }
                            else
                            {
                                continueToNexti = true;
                            }
                        }
    
                    }
                    output.Text += Environment.NewLine;
                }
            }
