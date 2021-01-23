            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("key 1", "value 1");
            values.Add("key 2", "value 2");
            values.Add("key 3", "value 3");
            RadioButtonList radioButtonList = new RadioButtonList();
            radioButtonList.DataTextField = "Value";
            radioButtonList.DataValueField = "Key";
            radioButtonList.DataSource = values;
            radioButtonList.DataBind();
