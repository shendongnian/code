    string pattern = "Info.Valid(\"\"{0}\"\", \"\"{1}\"\", \"\"{2}\"\", \"\"{3}\"\", \"\"{4}\")";
    string data = string.Format(pattern,
                combobox1.SelectedValue.ToString(),
                label1.Text,
                label2.Text,
                label3.Text,
                numericupdown.Value.ToString());
    start.Statements.Add(new CodeVariableReferenceExpression(data));
