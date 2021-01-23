        string gr = comboBox1.ValueMember;
        decimal sum = 0M;
        decimal rite;
        decimal left;
        try
        {
            rite = Convert.ToDecimal(textBox1.Text);
            left = Convert.ToDecimal(textBox2.Text);
        }
        catch (Exception)
        {
            string swr = "Please enter REAL a number, can be with decimals";
            label2.Text = swr;
        }
        switch (gr)
        {
            case "X":
                sum = rite * left;
                break;
            case "/":
                break;
            case "*":
                break;
            case "-":
                break;
            default:
                break;
        }
        answerText.Text = Convert.ToString(sum);
    }
