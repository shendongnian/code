    foreach (var c in text)
    {
       buffer.Append(c);
       if (c== '[' && mode == Text) 
       { 
          mode = Tag;
          
          Controls.Add(new LiteralControl(buffer));
          buffer.Clear();
       }
       if (c == ']' && mode == Tag) 
       {   
          mode = Text;
          
          switch (buffer)
          {
             case "[name]": Controls.Add(new NameControl());
             ... the rest of possible tags
          }
          buffer.Clear();
    }
