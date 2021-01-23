    // Initialize a string and write Your message it will work
    string message = "Helloq World";
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    sb.Append("alert('");
    sb.Append(message);
    sb.Append("');");
    ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
