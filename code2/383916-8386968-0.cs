    void MakeBind()
    {
         Binding bind = new Binding("Width", textBox3, "Text");
         bind.Format += new ConvertEventHandler(bind_Format);
         panel1.DataBindings.Add(bind);
    }
    void bind_Format(object sender, ConvertEventArgs e)
    {
         int i = 0;
         int.TryParse((string)e.Value, out i);
         e.Value = i;
    }
