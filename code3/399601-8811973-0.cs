        class Point
        {
            public Point(int x, int y) { this.x = x; this.y = y; }
            public double x { get; set; }
            public double y { get; set; }
        }
    
    public Point ParseString(string parm)
    {
        //input shall be: string s = x12y04;
        //inp s looks like x12y04
    
        //splut the string on the Y (so this tech should also work for x89232y329)
        //so this will create res[0] that is x89232 and an res[1] that is 329
        string[] res = parm.Split(new string[] { "y" }, StringSplitOptions.RemoveEmptyEntries);
        //now for the x in res[0], we replace it for a 0 so it are all numbers
        string resx = res[0].Replace("x", "0");
    
        //now we will get the strings to doubles so we can really start using them.
        double x = double.Parse(resx);
        double y = double.Parse(res[1]);
    
        //get the values back
        return new Point(x,y);
    
    }
