    StringBuilder stringBuilder = new StringBuilder();
        foreach (var control in placeHolder1.Controls)
        {
            var rad = control as RadioButton;
            if (rad != null)
            {
                if (rad.Checked)
                    stringBuilder.AppendLine(String.Format("Radion Button Checked : {0}", rad.ID));
            }
        }
        Response.Write(stringBuilder.ToString());
