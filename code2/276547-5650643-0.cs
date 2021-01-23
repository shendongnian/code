    private Dictionary<string, Form2> forms = new Dictionary<string, Form2>();
    public void Send(string body, string name)
    {
        if(forms.ContainsKey(name))
        {
            forms[name].AddNewItem(body);
        }
        else{
            Form2 form2 = new Form2(body);
            form2.Text = name;
            forms.Add(name, form2);  
            form2.ShowDialog();
        }
    } 
