    private void button1_Click(object sender, EventArgs e)
            {
                double celsius;
                double fahrenheit;
                string value;
                double finalValue;
    
                if (textBox1.Text.Length > 0)
                {
                    bool successCelsius = double.TryParse(textBox1.Text, out celsius);
    
                    if (successCelsius == false)
                    {
                        label6.Text = ("ERROR: Please enter a numeric temperature to convert.");
                        return;
                    }
                    else
                    {
                        celsius = Convert.ToDouble(textBox1.Text);
                        finalValue = (celsius * 9) / 5 + 32;
                        label6.Text = finalValue.ToString();
                        label6.Text = celsius + " " + "degrees Celsius converts to" + " " + finalValue + " " + "degrees Fahrenheit";
                    }
                }
                else
                {
                    bool successFahrenheit = double.TryParse(textBox2.Text, out fahrenheit);
    
    
                    if (successFahrenheit == false)
                    {
                        label6.Text = ("ERROR: Please enter a numeric temperature to convert.");
                        return;
                    }
                    else
                    {
                        fahrenheit = Convert.ToDouble(textBox2.Text);
                        finalValue = (fahrenheit - 32) * 5 / 9;
                        value = finalValue.ToString();
                        label6.Text = fahrenheit + " " + "degrees Fahrenheit converts to" + " " + finalValue + " " + "degrees Celsius";
                    }
                }
            }
