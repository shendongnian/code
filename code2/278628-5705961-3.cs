    void recognizer_SpeechRecognizedPizza(object sender, SpeechRecognizedEventArgs e)
    {
        // set the default semantic key values if the result does not include these
        string size = "regular";
        string crust = "thick crust";
        string topping = "cheese";
        if (e.Result.Semantics != null && e.Result.Semantics.Count != 0)
        {
            if (e.Result.Semantics.ContainsKey("size"))
            {
                size = e.Result.Semantics["size"].Value.ToString();
                AppendTextOuput(String.Format("\r\n  Size = {0}.", size));
            }
            if (e.Result.Semantics.ContainsKey("crust"))
            {
                crust = e.Result.Semantics["crust"].Value.ToString();
                AppendTextOuput(String.Format("\r\n  Crust = {0}.", crust));
            }
            if (e.Result.Semantics.ContainsKey("topping"))
            {
                topping = e.Result.Semantics["topping"].Value.ToString();
                AppendTextOuput(String.Format("\r\n  Topping = {0}.", topping));
            }
        }
        String sOutput = String.Format("\r\nRecognized: You have orderd a {0}, {1}, {2} pizza.", size, crust, topping);
        AppendTextOuput(sOutput);
    }
