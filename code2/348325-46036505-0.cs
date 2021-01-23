    public void ParseControlText_WithExtensions()
    {
        try
        {
            var doubleval = tb_double.PasrseDouble();
            var intval    = tb_int.ParseInt();
            //with syntactic sugar
            var doubleval2 = Double.Parse(tb_double);
            var intval2    = Int32.Parse(tb_int);
        }
        catch (FormatException ex)
        {
             (PasrseHelper._lastControl as Textbox).Focus();
             MessageBox.Show("Coundt Be Parsed") ;
        }
    }
    public static class ParseHelper
    {
        public static control  _lastControl ;
        public static ParseDouble(this Control ctrl )
        {
            //Assuming its always .Text Property that will be parsed
            _lastControl = ctrl;
            return double.Parse( ctrl.Text);
        }
        public static ParseInt(this Control ctrl )
        {
            _lastControl = ctrl;
            return Int32.Parse( ctrl.Text);
        }
    }
    // if you prefer  original syntax
    public static class Double
    {
        public static Parse(this Control ctrl )
        {
            //Assuming its always .Text Property that will be parsed
            ParseHelper._lastControl = ctrl;
            return double.Parse( ctrl.Text);
        }
    }
    public static class Int32
    {
        public static Parse(this Control ctrl )
        {
            //Assuming its always .Text Property that will be parsed
            ParseHelper._lastControl = ctrl;
            return Int32.Parse( ctrl.Text);
        }
    }
