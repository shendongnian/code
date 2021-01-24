        int num1;
        bool res = int.TryParse(txtUprice.Text, out num1);
        if (res == false)
        {
            MessageBox.Show("String is not a number");
        }
        else{
            MessageBox.Show(num1.ToString()); 
        }
