    private void btnAdd_Click(object sender, EventArgs e)
    {
        double callories = 0;
        double price = 0;
        string text = "";
        int sum1 = 0;
        foreach (Control x in grpTypesOfIcecream.Controls)
        {
            if (x is NumericUpDown)
            {
                int number = (int)((NumericUpDown)x).Value;
                    sum1 += number;
                    callories += (133 * sum1);
                    if (sum1 == 1)
                    {
                        price += 2.1;
                        text += "one scoop of ice";
                    }
                    else if (sum1 == 2)
                    {
                        price += 3.8;
                        text += "two scoops of ice";
                    }
                    else if (sum1 == 3)
                    {
                        price += 5.1;
                        text += "three scoops of ice";
                    }
            }
        }
    }
