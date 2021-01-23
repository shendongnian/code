    using System.Diagnostics;
    public void ParseControlText()
    {
        try
        {
            var doubleval = Double.Parse(tb_double.Text);
            var intval    = Int32.Parse(tb_int.Text);
            //... bunch of controls need to be parssed to calculate  something
        }
        catch (FormatException ex)
        {
            var stlast = new StackTrace(ex,true).GetFrames().Last();
           
           //this requires   form.cs to exist . how am i gonna do this in release? idk
            var stLine = File.ReadLines(stlast.GetFileName())
                .ToList()[stlast.GetFileLineNumber()-1];
            var m = Regex.Match(stLine ,@"\((.*?)\..*?\)"); 
            var ctrlname = m.Groups[1].Value;
            MessageBox.Show( ctrlname + " control's text coundnt be Parsed! " );
        }
    }
