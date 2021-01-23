    using(StreamReader sr = new StreamReader(label1.Text))
    {
       String strNumVertices = sr.ReadLine();
       label2.Text = strNumVertices;
    }
