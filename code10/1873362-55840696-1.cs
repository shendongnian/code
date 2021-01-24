    public void test() {
        for (int i = 0; i < 10; i++)
            if (i<5)
            {
                //create radiobutton
                radiobutton btn = new radiobutton
                {
                    Text = "Click to Rotate Text!",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Center,
                    tag = i
                };
                Console.WriteLine(btn.tag);
            }
            else if (i > 2)
            {
                //create ratingview
            }
    }
    public class radiobutton : Button
    {
        public int tag;
    }
