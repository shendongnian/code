        try
        {
            Form1.ActiveForm.Hide();
            // ...
        }
        catch (Exception i)
        {
            // ...
        }
        finally
        {
            Form1.Show();
        }
